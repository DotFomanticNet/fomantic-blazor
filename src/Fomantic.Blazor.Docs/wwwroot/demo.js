window.demo = {
    togglePropSheet: async function (elemnt, elemnt2, sampleComponent) {

        $(elemnt)
            .sidebar({
                transition: "overlay",
                silent: true,
                dimPage: false,
                onHidden: async function () {

                    await sampleComponent.invokeMethodAsync("Close");
                }
            })
            .sidebar('toggle');
        $(elemnt2)
            .sidebar({
                transition: "overlay",
                dimPage: false,
                silent: true,
                onHidden: async function () {

                    await sampleComponent.invokeMethodAsync("Close");
                }
            })
            .sidebar('toggle');
    },
    initPropSheetElements: function () {
        setTimeout(function () { $('.ui.checkbox').checkbox(); }, 500);

    },
    editorInit: async function (element, language) {
        let promise = new Promise((resolve, reject) => {
            require.config({ paths: { 'vs': 'editor/vs' } });
            require(['vs/editor/editor.main'], function () {
                var editor = monaco.editor.create(element, {
                    readOnly: true,
                    formatOnType: true,//!important
                    value: [
                        ''
                    ].join('\n'),
                    language: language,
                    automaticLayout: true,

                });

                resolve(editor);
            });
        });
        var s = await promise;

        return s
    },
    codeEditorInit: async function (element) {
        let promise = new Promise((resolve, reject) => {
            require.config({ paths: { 'vs': 'editor/vs' } });
            require(['vs/editor/editor.main'], function () {
                var editor = monaco.editor.create(element, {
                    formatOnType: true,//!important
                    value: [
                        ''
                    ].join('\n'),
                    language: 'razor',
                    automaticLayout: true,

                });

                resolve(editor);
            });
        });
        var s = await promise;

        return s
    },
    addComponentModalInit: async function (element) {
        $('.ui.radio.checkbox')
            .checkbox();
        $('.selection.dropdown')
            .dropdown();
    },
    copyText: function (text) {
        navigator.clipboard.writeText(text).then(function () {
            $('body')
                .toast({
                    class: 'success',
                    message: `Code Copied`
                });
        })
            .catch(function (error) {
                alert(error);
            });
    },
    applyHash: function (text) {
        window.location.hash = "#" + text;
    }
}

//========================================
function saveAsFile(filename, bytesBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + bytesBase64;
    document.body.appendChild(link); // Needed for Firefox
    link.click();
    document.body.removeChild(link);
}

// ready event
window.semantic = {
    ready: function () {
        setTimeout(function () {

            $('.ui.sticky')
                .sticky({
                    silent: true,
                    offset: 30
                });
            $('.ui.accordion').accordion();

            $('.example').visibility({
                once: false,
                silent:true,
                onTopPassed: function (calculations) {
                    var id = $(this).attr('id');

                    window.location.hash = "#" + id;
                    var elem = $("[data-for='" + id + "']");
                    var accordion = elem.closest('.ui.vertical.following.fluid.accordion.text.menu');
                  
                    accordion.find('.active').removeClass('active');
                    elem.closest('.content.menu').addClass("active");
                    elem.addClass("active");
                },
                onTopPassedReverse: function (calculations) {
                    var id = $(this).attr('id');

                    window.location.hash = "#" + id;
                    var elem = $("[data-for='" + id + "']");
                    var accordion = elem.closest('.ui.vertical.following.fluid.accordion.text.menu');

                    accordion.find('.active').removeClass('active');
                    elem.closest('.content.menu').addClass("active");
                    elem.addClass("active");
                }
            });

          
        }, 300);
    }
};
