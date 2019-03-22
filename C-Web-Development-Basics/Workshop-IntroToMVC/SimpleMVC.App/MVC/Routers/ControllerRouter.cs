namespace SimpleMVC.App.MVC.Routers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using SimpleHttpServer.Models;
    using Attributes.Methods;
    using Contollers;
    using Interfaces;
    using SimpleHttpServer.Enums;

    public class ControllerRouter : IHandleable
    {
        private IDictionary<string, string> getParams;
        private IDictionary<string, string> postParams;
        private string requestMethod;
        private string controllerName;
        private string actionName;
        private object[] methodParams;

        public HttpResponse Handle(HttpRequest request)
        {
            if (request.Url.Contains("?"))
            {
                int indexOfQuestionMark = request.Url.IndexOf('?');
                string getParameters = WebUtility.UrlDecode(request.Url.Substring(indexOfQuestionMark + 1));
                getParams = RetrieveParameters(getParameters);

            }
            else if (!String.IsNullOrEmpty(request.Content))
            {
                string contentString = WebUtility.UrlDecode(request.Content);
                postParams = RetrieveParameters(contentString);
            }

            this.requestMethod = request.Method.ToString();

            this.RetrieveControllerAndActionName(request.Url);

            MethodInfo method = this.GetMethod();

            if (method == null)
            {
                throw new NotSupportedException("No such method");
            }

            IEnumerable<ParameterInfo> parameters = method.GetParameters();
            this.methodParams = new object[parameters.Count()];
            int index = 0;
            foreach (ParameterInfo param in parameters)
            {
                if (param.ParameterType.IsPrimitive)
                {
                    object value = this.getParams[param.Name];
                    this.methodParams[index] = Convert.ChangeType(value, param.ParameterType);
                    index++;
                }
                else
                {
                    Type bindingModelType = param.ParameterType;
                    object bindingModel = Activator.CreateInstance(bindingModelType);

                    IEnumerable<PropertyInfo> properties = bindingModelType.GetProperties();

                    foreach (PropertyInfo property in properties)
                    {
                        property.SetValue(bindingModel, Convert.ChangeType(postParams[property.Name],property.PropertyType));
                    }
                    this.methodParams[index] = Convert.ChangeType(bindingModel, bindingModelType);
                    index++;
                }
            }

            IInvocable actionResult = (IInvocable) this.GetMethod()
                .Invoke(this.GetController(), this.methodParams);

            string content = actionResult.Invoke();
            var response = new HttpResponse()
            {
                StatusCode = ResponseStatusCode.Ok,
                ContentAsUTF8 = content
            };
            return response;
        }

        private void RetrieveControllerAndActionName(string requestUrl)
        {
            string[] urlParams = requestUrl.Split('/');
            if (urlParams.Length == 3)
            {
                string controller = urlParams[1];
                string fixedControllerName = controller[0].ToString().ToUpper() + controller.Substring(1) + "Controller";
                string action = urlParams[2];
                string fixedActionName = "";
                fixedActionName = action[0].ToString().ToUpper() + action.Substring(1);
                int indexOfQuestioMark = fixedActionName.IndexOf('?');
                if (indexOfQuestioMark != -1)
                {
                    fixedActionName = fixedActionName.Substring(0, indexOfQuestioMark);
                }
                this.controllerName = fixedControllerName;
                this.actionName = fixedActionName;
            }
            else
            {
                throw new ArgumentException("Invalid URL");
            }
        }

        private IDictionary<string,string> RetrieveParameters(string parametersString)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            string[] paramsInfo = WebUtility.UrlDecode(parametersString).Split('&');
            foreach (var param in paramsInfo)
            {
                string[] paramNameValue = param.Split('=');
                parameters.Add(paramNameValue[0], paramNameValue[1]);
            }
            return parameters;
        }

        private MethodInfo GetMethod()
        {
            MethodInfo method = null;
            foreach (MethodInfo methodInfo in this.GetSuitableMethods())
            {
                IEnumerable<Attribute> attributes = methodInfo
                    .GetCustomAttributes()
                    .Where(a => a is HttpMethodAttribute);
                if (!attributes.Any())
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.isValid(this.requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }
            return method;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods()
        {
            return this.GetController()
                .GetType()
                .GetMethods()
                .Where(m => m.Name == this.actionName);
        }

        private Controller GetController()
        {
            var controllerType = string.Format("{0}.{1}.{2}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ControllersFolder,
                this.controllerName);

            var controller = (Controller) Activator.CreateInstance(Type.GetType(controllerType));
            return controller;
        }
    }
}