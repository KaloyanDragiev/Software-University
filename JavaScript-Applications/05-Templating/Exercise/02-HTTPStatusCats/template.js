$(() => {
    let source = $('#cat-template').html();
    let catTemplate = Handlebars.compile(source);

    renderCatTemplate();

    function renderCatTemplate() {
        for (let cat of window.cats){
            $('#allCats').append(catTemplate(cat))
        }
        $('.btn-primary').click(showHideStatus);

        function showHideStatus(){
            if ($(this).text() === 'Show status code')
                $(this).text('Hide status code');
            else
                $(this).text('Show status code');
            $(this).next().toggle();
        }
    }
});