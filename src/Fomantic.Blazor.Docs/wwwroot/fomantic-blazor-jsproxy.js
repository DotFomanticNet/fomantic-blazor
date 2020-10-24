
window.animator = {
    animate: async function (element, animation, duration) {
        console.log('aaa')
        let promise = new Promise((resolve, reject) => {
            $(element)
                .transition({
                    animation: animation,
                    duration: duration,
                    onComplete: function () {
                        resolve();
                    }
                });
        });
       
        await promise;
    },
    animateMultible: async function (element, animations) {

        let promise = new Promise((resolve, reject) => {
            var ani = $(element);
            var lastanmi = animations.reverse()[0];
            animations.forEach(anim => {
                
                if (lastanmi == anim) {
                    ani = ani.transition({
                        animation: anim.animation,
                        duration: anim.duration,
                        onComplete: function () {
                            resolve();
                        }
                    });
                } else {
                    ani = ani.transition({
                        animation: anim.animation,
                        duration: anim.duration,
                    });
                }
                
            });

        });

        await promise;
    },
    animateElements: async function (elements, animation, duration, interval) {
        var rand = Math.floor(Math.random() * 100000);
       
        elements.forEach(element => $(element).attr('data-animation-group', rand));
        let promise = new Promise((resolve, reject) => {
            $("[data-animation-group='" + rand + "']")
                .transition({
                    interval: interval,
                    animation: animation,
                    duration: duration,
                    onComplete: function () {
                        resolve();
                    }
                });
        });
       
        await promise;
        elements.forEach(element => $(element).removeAttr('data-animation-group'));
    },
    animateElementsMultible: async function (elements, animations, interval) {
        var rand = Math.floor(Math.random() * 100000);
      
        elements.forEach(element => $(element).attr('data-animation-group', rand));
        let promise = new Promise((resolve, reject) => {
            var ani = $("[data-animation-group='" + rand + "']");
            var lastanmi = animations.reverse()[0];
            animations.forEach(anim => {

                if (lastanmi == anim) {
                    ani = ani.transition({
                        interval: interval,
                        animation: anim.animation,
                        duration: anim.duration,
                        onComplete: function () {
                            resolve();
                        }
                    });
                } else {
                    ani = ani.transition({
                        interval: interval,
                        animation: anim.animation,
                        duration: anim.duration,
                    });
                }

            });
        });

        await promise;
        elements.forEach(element => $(element).removeAttr('data-animation-group'));
    }
}

window.element = {
    initVisibilityEvents: async function (element, dotNetObject) {
        var onUpdateSubscribed = await dotNetObject.invokeMethodAsync("UpdateSubscribed");
        var onTopVisibleSubscribed = await dotNetObject.invokeMethodAsync("OnTopVisibleSubscribed");
        var onTopPassedSubscribed = await dotNetObject.invokeMethodAsync("OnTopPassedSubscribed");
        var onBottomVisibleSubscribed = await dotNetObject.invokeMethodAsync("OnBottomVisibleSubscribed");
        var onPassingSubscribed = await dotNetObject.invokeMethodAsync("OnPassingSubscribed");
        var onBottomPassedSubscribed = await dotNetObject.invokeMethodAsync("OnBottomPassedSubscribed");
        var onTopVisibleReverseSubscribed = await dotNetObject.invokeMethodAsync("OnTopVisibleReverseSubscribed");
        var onTopPassedReverseSubscribed = await dotNetObject.invokeMethodAsync("OnTopPassedReverseSubscribed");
        var onBottomVisibleReverseSubscribed = await dotNetObject.invokeMethodAsync("OnBottomVisibleReverseSubscribed");
        var onPassingReverseSubscribed = await dotNetObject.invokeMethodAsync("OnPassingReverseSubscribed");
        var onBottomPassedReverseSubscribed = await dotNetObject.invokeMethodAsync("OnBottomPassedReverseSubscribed");
        $(element)
            .visibility({
                once: false,
                onTopVisible: (onTopVisibleSubscribed ? function (calculations) {
                    dotNetObject.invokeMethodAsync("OnTopVisible", calculations);
                } : null),
                onTopPassed: (onTopPassedSubscribed ? function (calculations) {
                    dotNetObject.invokeMethodAsync("OnTopPassed", calculations);
                } : null),
                onBottomVisible: (onBottomVisibleSubscribed ? function (calculations) {
                    dotNetObject.invokeMethodAsync("OnBottomVisible", calculations);
                } : null),
                onPassing: (onPassingSubscribed ? function (calculations) {

                    dotNetObject.invokeMethodAsync("OnPassing", calculations);
                } : null),
                onBottomPassed: (onBottomPassedSubscribed ? function (calculations) {
                    dotNetObject.invokeMethodAsync("OnBottomPassed", calculations);
                } : null),
                onTopVisibleReverse: (onTopVisibleReverseSubscribed ? function (calculations) {
                    dotNetObject.invokeMethodAsync("OnTopVisibleReverse", calculations);
                } : null),
                onTopPassedReverse: (onTopPassedReverseSubscribed ? function (calculations) {
                    dotNetObject.invokeMethodAsync("OnTopPassedReverse", calculations);
                } : null),
                onBottomVisibleReverse: (onBottomVisibleReverseSubscribed ? function (calculations) {
                    dotNetObject.invokeMethodAsync("OnBottomVisibleReverse", calculations);
                } : null),
                onPassingReverse: (onPassingReverseSubscribed ? function (calculations) {
                    dotNetObject.invokeMethodAsync("OnPassingReverse", calculations);
                } : null),
                onBottomPassedReverse: (onBottomPassedReverseSubscribed ? function (calculations) {
                    dotNetObject.invokeMethodAsync("OnBottomPassedReverse", calculations);
                } : null),
                onUpdate: (onUpdateSubscribed ? function (calculations) {
                    dotNetObject.invokeMethodAsync("OnUpdate", calculations);
                } : null),

            });
    },
    destroyVisibilityEvents: async function (element) {
        $(element)
            .visibility({
                onTopVisible: null,
                onTopPassed: null,
                onBottomVisible: null,
                onPassing: null,
                onBottomPassed: null,
                onTopVisibleReverse: null,
                onTopPassedReverse: null,
                onBottomVisibleReverse: null,
                onPassingReverse: null,
                onBottomPassedReverse: null,
                onUpdate: null,
            });
    },
    show: async function (element) {
        $(element).show();
    },
    hide: async function (element) {
        $(element).hide();
    },
    toggleVisibility: async function (element) {
        $(element).toggle();
    },
}
