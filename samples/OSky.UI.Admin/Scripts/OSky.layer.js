
document.write('<script src="/Scripts/layer-2.0/layer.js"></script>');
document.write('<script src="/Scripts/layer-2.0/extend/layer.ext.js"></script>');
(function ($) {
    $.OSky = $.OSky || { version: 1.0 };
    $.OSky.layer = $.OSky.layer || {};
})(jQuery);
(function ($) {
    $.OSky.layer.msg = {
        tip: function (content) {
            layer.msg(content ,{
            //icon: 4,
            time: 1500 //1.5秒关闭（如果不配置，默认是3秒）
        });
        },
        loading: function (type) {
            //加载层-风格3
            layer.load(type?type:0);
            //此处演示关闭
            setTimeout(function () {
                layer.closeAll('loading');
            }, 2000);
        },
        info: function (content) {
            //layer.alert(content, {
            //    skin: 'layui-layer-molv' //样式类名 墨绿深蓝风
            //    , closeBtn: 0 });
            layer.alert(content, { icon: 6 });
        },
        error: function (content) {
            layer.alert(content, { icon: 5 });
        },
        open: function (type,content, btn, onYes, onCancel, title, width, height,optionClose) {        //弹出层-父子操作
            layer.open({
                type: type,                     //基本层类型(类型：Number，默认：0 信息框 1 页面层2 iframe层 3 加载层 4 tips层 )
                content: content,               //内容（type=1 content可传入任意的文本或html；type=2 content是一个URL）
                title: title,                   //标题（类型：String/Array/Boolean，默认：'信息'）
                //skin: 'layui-layer-molv',     //样式类名 墨绿深蓝风
                area: [width ? width : '500px', height ? height : '550px'],      //宽高（类型：String/Array，默认：'auto'）
                fix: false,                     //不固定
                maxmin: true,                   //最大最小化(类型：Boolean，默认：false)
                btn: btn == true ? ['确定', '取消'] : null,       //按钮（类型：String/Array，默认：'确认'）
                yes: function (index, layero) {                   //或者使用btn1
                    if (onYes && (typeof onYes) == "function")
                        onYes(index, layero);                     //按钮【按钮一】的回调
                    if (optionClose != "undefined" && optionClose != false)
                        layer.close(index);              //关闭弹出层必须进行手工关闭
                    
                },
                cancel: function (index) {                        //或者使用btn2
                    if (onCancel && (typeof onCancel) == "function")
                        onCancel(index);                          //按钮【按钮二】的回调
                },
            });
        },
        full: function (type, content, btn, onYes, onCancel, title, optionClose) {
            var index = layer.open({
                type: type,                     //基本层类型(类型：Number，默认：0 信息框 1 页面层2 iframe层 3 加载层 4 tips层 )
                content: content,               //内容（type=1 content可传入任意的文本或html；type=2 content是一个URL）
                title: title,                   //标题（类型：String/Array/Boolean，默认：'信息'）
                //skin: 'layui-layer-molv',     //样式类名 墨绿深蓝风
                maxmin: true,                   //最大最小化(类型：Boolean，默认：false)
                btn: btn == true ? ['确定', '取消'] : null,       //按钮（类型：String/Array，默认：'确认'）
                yes: function (index, layero) {                   //或者使用btn1
                    if (onYes && (typeof onYes) == "function")
                        onYes(index, layero);                     //按钮【按钮一】的回调
                    if (optionClose != "undefined" && optionClose != false)
                        layer.close(index);              //关闭弹出层必须进行手工关闭
                   
                },
                cancel: function (index) {                        //或者使用btn2
                    if (onCancel && (typeof onCancel) == "function")
                        onCancel(index);                          //按钮【按钮二】的回调
                },
            });
            layer.full(index);
        },
        confirm: function (content, onOk, onCancel) {
            layer.confirm(content, { icon: 3 }, function (index) {
                if (onOk && (typeof onOk) == "function") {
                    onOk();
                    return;
                }
                if (onCancel && (typeof onCancel) == "function") {
                    onCancel();
                }
                layer.close(index);
            });
        },
        prompt: function (title1, title2, onFun) { //prompt层onFun(opt) opt{ pass: pass, context: text }
            layer.prompt({
                title: title1,
                formType: 1 //prompt风格，支持0-2
            }, function (pass) {
                layer.prompt({ title: title2, formType: 2 }, function (text) {
                    if (onFun && (typeof onFun) == "function") {
                        var opt = { pass: pass, context: text };
                        onFun(opt);
                    }
                });
            });
        },
        tab: function (tab, width, height) {//tab层 tab[{title: 'TAB1',content: '内容1'}, {title: 'TAB2',content: '内容2'}]
            layer.tab({
                area: [width ? width : '800px', height ? height : '550px'],
                tab: tab
            });
        }
    };

})(jQuery);

