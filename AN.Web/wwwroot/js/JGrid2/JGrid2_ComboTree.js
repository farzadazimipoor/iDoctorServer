function loadCustomeComboTreeById(treeId) {
    var showCheckBox = false;
    $("#" + treeId).fancytree({
        checkbox: showCheckBox,
        selectMode: 3,        
        select: function (e, data) {
            var selNodes = data.tree.getSelectedNodes();
            var selKeys = $.map(selNodes, function (node) {
                return node.key;
            });
            $("[data-tree='"+treeId+"']").val(selKeys.join(","));
        },
        click: function (e, data) {
            $("[data-tree='"+treeId+"']").val(data.node.key);
            if ($.ui.fancytree.getEventTargetType(e) == "title") {
                data.node.toggleSelected();
            }
            setTree(treeId, data.node.key, data.node.title);
           // alert(data.node);
            //if (_afterComboTreeClickedFunc)
            //    window[_afterComboTreeClickedFunc](data.node);
        },
        keydown: function (e, data) {
            if (e.which === 32) {
                data.node.toggleSelected();
                return false;
            }
        }
    });
}