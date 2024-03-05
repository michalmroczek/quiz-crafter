export function init(id, group, pull, put, sort, handle, filter, component, forceFallback) {
    var sortable = new Sortable(document.getElementById(id), {
        animation: 200,
        group: {
            name: group,
            pull: pull || true,
            put: put
        },
        filter: filter || undefined,
        sort: sort,
        forceFallback: forceFallback,
        handle: handle || undefined,
        onUpdate: (event) => {
            // Revert the DOM to match the .NET state
            event.item.remove();
            event.to.insertBefore(event.item, event.to.childNodes[event.oldIndex]);

            // Notify .NET to update its model and re-render
            component.invokeMethodAsync('OnUpdateJS', event.oldDraggableIndex, event.newDraggableIndex);
        },
        onRemove: (event) => {
            event.item.remove();
            if (event.pullMode !== 'clone') {
                // Remove the clone
                // event.clone.remove();
                event.from.insertBefore(event.item, event.from.childNodes[event.oldIndex]);
            }




            // Notify .NET to update its model and re-render
            component.invokeMethodAsync('OnRemoveJS', event.oldDraggableIndex, event.newDraggableIndex);
        },
        onAdd: (event) => {
            component.invokeMethodAsync('OnAddJS', event.oldDraggableIndex, event.newDraggableIndex);
        },
        onStart: (event) => {
            var myDiv = document.querySelector(".drop-zone");
            myDiv.style.border = "5px dashed purple";
            component.invokeMethodAsync('OnEndJS', event.newDraggableIndex);
        },
        onEnd: (event) => {
            var myDiv = document.querySelector(".drop-zone");
            myDiv.style.border = "";
            component.invokeMethodAsync('OnEndJS', event.newDraggableIndex);
        },
        onClone: (event) => {

            component.invokeMethodAsync('OnCloneJS', event.newDraggableIndex);
        },
    });
}