﻿function TreeHelper(list) {
	this.list = list;
}
(function (TreeHelper) {
	function getAllChildren(list, item) {
		var children = getNextLevelChildren(list, item);
		for (var i = 0, ii = children.length; i < ii; i++) {
			getAllChildren(list, children[i]);
		}
	}
	//遍历list剩下的数据，找到item的下一层的子节点
	function getNextLevelChildren(list, item) {
		var children = [];
		for (var i = list.length - 1; i >= 0; i--) {
			var mid = list[i];
			if (mid.pid === item.id) {
				delete mid.pid;
				children.push(mid);
				list.splice(i, 1);
			}
		}
		if (children.length > 0) {
			item.children = children;
		}
		return children;
	}
	TreeHelper.prototype.dataTransferer = function () {
		var list = this.list;
		//根节点必须在数组前面
		list.sort(function (a, b) {
			if (a.pid > b.pid) {
				return 1;
			} else {
				return -1;
			}
		});
		var item,
            result = [];
		//遍历根节点，递归处理其所有子节点的数据
		//每处理完一个根节点，就将其及其所有子节点从list中删除，加快递归速度
		while (list.length) {
			item = list[0];
			list.splice(0, 1);
			delete item.pid;
			getAllChildren(list, item);
			result.push(item);
		}
		return result;
	};
})(TreeHelper);