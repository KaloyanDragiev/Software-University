function extractModules(input){
    let modules = new Map();
    let unassignedControllers = new Map();
    let unassignedModels = new Map();
    let unassignedViews = new Map();

    for (let line of input){
        let appPattern = /^\$app='([^']+)'$/g;
        let controllerPattern = /^\$controller='([^']+)'&app='([^']+)'$/g;
        let modelPattern = /^\$model='([^']+)'&app='([^']+)'$/g;
        let viewPattern = /^\$view='([^']+)'&app='([^']+)'$/g;

        let appInfo = appPattern.exec(line);
        let controllerInfo = controllerPattern.exec(line);
        let modelInfo = modelPattern.exec(line);
        let viewInfo = viewPattern.exec(line);

        if (appInfo){
            let appName = appInfo[1];
            modules.set(appName, new Map());
            modules.get(appName).set('controllers', new Set());
            modules.get(appName).set('models', new Set());
            modules.get(appName).set('views', new Set());
        }
        else if (controllerInfo){
            let appToAssignTo = controllerInfo[2];
            let controllerName = controllerInfo[1];
            if (modules.has(appToAssignTo))
                modules.get(appToAssignTo).get('controllers').add(controllerName);
            else
                unassignedControllers.set(controllerName + ',' + appToAssignTo, appToAssignTo);
        }
        else if (modelInfo){
            let appToAssignTo = modelInfo[2];
            let modelName = modelInfo[1];
            if (modules.has(appToAssignTo))
                modules.get(appToAssignTo).get('models').add(modelName);
            else
                unassignedModels.set(modelName + ',' + appToAssignTo, appToAssignTo);
        }
        else if (viewInfo){
            let appToAssignTo = viewInfo[2];
            let viewName = viewInfo[1];
            if (modules.has(appToAssignTo))
                modules.get(appToAssignTo).get('views').add(viewName);
            else
                unassignedViews.set(viewName + ',' + appToAssignTo, appToAssignTo);
        }
    }

    for (let [controller, app] of unassignedControllers)
        if (modules.has(app))
            modules.get(app).get('controllers').add(controller.split(',')[0]);

    for (let [model, app] of unassignedModels)
        if (modules.has(app))
            modules.get(app).get('models').add(model.split(',')[0]);

    for (let [view, app] of unassignedViews)
        if (modules.has(app))
            modules.get(app).get('views').add(view.split(',')[0]);

    let orderedModules = Array.from(modules).sort(sortModules);
    let result = {};

    for (let [module, sets] of orderedModules){
        let controllers = Array.from(modules.get(module).get('controllers')).sort(sortElements);
        let models = Array.from(modules.get(module).get('models')).sort(sortElements);
        let views = Array.from(modules.get(module).get('views')).sort(sortElements);
        result[module] = {controllers, models, views};
        }
    console.log(JSON.stringify(result));

    function sortModules(m1, m2){
        if (m1[1].get('controllers').size > m2[1].get('controllers').size)                            // DESC
            return -1;
        if (m1[1].get('controllers').size < m2[1].get('controllers').size)
            return 1;
        if (m1[1].get('models').size < m2[1].get('models').size)         // ASCENDING
            return -1;
        if (m1[1].get('models').size > m2[1].get('models').size)
            return 1;
        return 0;
    }

    function sortElements(e1, e2) {
        return e1.localeCompare(e2) // ASC Alphabetical Order
    }
}

extractModules([
    '$controller=\'PHPController\'&app=\'Language Parser\'',
    '$controller=\'JavaController\'&app=\'Language Parser\'',
    '$controller=\'C#Controller\'&app=\'Language Parser\'',
    '$controller=\'C++Controller\'&app=\'Language Parser\'',
    '$app=\'Garbage Collector\'',
    '$controller=\'GarbageController\'&app=\'Garbage Collector\'',
    '$controller=\'SpamController\'&app=\'Garbage Collector\'',
    '$app=\'Language Parser\''

]);
