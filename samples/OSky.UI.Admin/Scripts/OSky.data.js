(function ($) {
    $.OSky = $.OSky || { version: 1.0 };
})(jQuery);
(function ($) {
    $.OSky.data = {
        bool: [{ id: false, text: "否" }, { id: true, text: "是" }],
        bools: function (txtFalse, txtTrue) {
            if (txtFalse == null) txtFalse = "否";
            if (txtTrue == null) txtTrue = "是";
            return [{ id: false, value: false, text: txtFalse }, { id: true, value: true, text: txtTrue }];
        },

        status: [{ id: "0", text: "启用" }, { id: "1", text: "禁用" }],
        operateTypes: [{ id: "0", text: "查询" }, { id: "10", text: "新建" }, { id: "20", text: "更新" }, { id: "30", text: "删除" }],
        functionTypes: [{ id: "0", text: "匿名访问" }, { id: "1", text: "登录访问" }, { id: "2", text: "角色访问" }],
        menuTypes: [{ id: "0", text: "其它" }, { id: "1", text: "菜单" }, { id: "2", text: "按钮" }],

        //获取远程数据更新Column的Editor数据
        updateColumnEditorData: function (url, columns, index) {
            $.getJSON(url, function (data) {
                var $columns = $(columns);
                $columns[index].editor.data = data;
            });
        }
    };
})(jQuery);