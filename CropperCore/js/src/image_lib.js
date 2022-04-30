import Cropper from "cropperjs";

let cropper;
let image;

export function createCrop(img, option, dotNetHelper, events) {
    if (!img) {
        // Exception
        return;
    }

    if ((events.ready || events.cropstart || events.cropend || events.cropmove || events.crop || events.zoom) && !dotNetHelper) {
        // Exception
        return;
    }

    console.log("events");
    console.log(events);
    console.log(events.ready);

    console.log(option);

    if (typeof img === 'string') {
        image = document.getElementById(img)
    }
    else {
        image = img;
    }

    if (cropper) {
        console.log("cropper destroy")
        cropper.destroy();
    }

    if (!dotNetHelper) {
        console.log("dotNetHelper null")
    }

    console.log("events.ready ???")

    if (events.ready) {
        console.log("events.ready true")
        addReady(dotNetHelper)
    }
    if (events.cropstart) {
        console.log("events.cropstart true")
        addCropStart(dotNetHelper)
    }
    if (events.cropmove) {
        console.log("events.cropmove true")
        addCropMove(dotNetHelper)
    }
    if (events.cropend) {
        console.log("events.cropend true")
        addCropEnd(dotNetHelper)
    }
    if (events.crop) {
        console.log("events.crop true")
        addCrop(dotNetHelper)
    }
    if (events.zoom) {
        console.log("events.zoom true")
        addZoom(dotNetHelper)
    }

    cropper = new Cropper(image, option);

    let x = cropper.cropped;

    console.log("x");
    console.log(x);
    console.log("cropper.cropped");
    console.log(cropper.cropped);
}

export function crop() {
    if (cropper) {
        cropper.crop();
    }
}

export function reset() {
    if (cropper) {
        cropper.reset();
    }
}

export function clear() {
    if (cropper) {
        cropper.clear();
    }
}

export function enable() {
    if (cropper) {
        cropper.enable();
    }
}

export function disable() {
    if (cropper) {
        cropper.disable();
    }
}

export function destroy() {
    if (cropper) {
        cropper.destroy();
    }
}

export function move(offsetX, offsetY) {
    if (cropper) {
        if (offsetY === null || offsetY === undefined) {
            cropper.move(offsetX);
        }
        else {
            cropper.move(offsetX, offsetY);
        }
    }
}

export function moveTo(x, y) {
    if (cropper) {
        if (y === null || y === undefined) {
            cropper.moveTo(x);
        }
        else {
            cropper.moveTo(x, y);
        }
    }
}

export function zoom(ratio) {
    if (cropper) {
        cropper.zoom(ratio);
    }
}

export function zoomTo(ratio, schema) {
    if (cropper) {
        if (schema) {
            cropper.zoomTo(ratio, schema);
        }
        else {
            cropper.zoomTo(ratio);
        }
    }
}

export function rotate(degree) {
    if (cropper) {
        cropper.rotate(degree);
    }
}

export function rotateTo(degree) {
    if (cropper) {
        cropper.rotateTo(degree);
    }
}

export function scale(scaleX, scaleY) {
    if (cropper) {
        if (scaleY) {
            cropper.scale(scaleX, scaleY);
        }
        else {
            cropper.scale(scaleX);
        }
    }
}

export function scaleX(scaleX) {
    cropper.scaleX(scaleX);
}

export function scaleY(scaleY) {
    cropper.scaleY(scaleY);
}

export function getData(rounded) {
    if (rounded) {
        return cropper.getData(rounded);
    }
    else {
        return cropper.getData();
    }
}

export function setData(data) {
    cropper.setData(data);
}

export function getContainerData() {
    return cropper.getContainerData();
}

export function getImageData() {
    return cropper.getImageData();
}

export function getCanvasData() {
    return cropper.getCanvasData();
}

export function setCanvasData(data) {
    cropper.setCanvasData(data);
}

export function getCropBoxData() {
    return cropper.getCropBoxData();
}

export function setCropBoxData(data) {
    cropper.setCropBoxData(data);
}

export function getCroppedCanvas(dest, options) {
    if (cropper) {
        let imgDest;

        if (!dest) {
            // Exception
            return;
        }
        if (typeof dest === 'string') {
            imgDest = document.getElementById(dest)
        }
        else {
            imgDest = dest;
        }
        //const prev = document.getElementById("imagePrev");
        //const prev = document.getElementById("canvas");
        //    prev.setAttribute("src", cropper.getCroppedCanvas({
        //        width: 800,
        //        height: 800,
        //        fillColor: '#fff',
        //        imageSmoothingEnabled: false,
        //        imageSmoothingQuality: 'high',
        //    }).toDataURL("image/jpeg"));
        imgDest.setAttribute("src", cropper.getCroppedCanvas(options).toDataURL("image/jpeg"));
    }
    else {
        alert("errore");
    }
}
export function getCroppedCanvasHTML(options) {
    if (cropper) {
        return cropper.getCroppedCanvas(options);
    }
    else {
        alert("errore");
    }
}

export function setAspectRatio(aspectRatio) {
    cropper.setAspectRatio(aspectRatio);
}

export function setDragMode(mode) {
    if (mode) {
        console.log(mode);
        cropper.setDragMode(mode);
    }
    else {
        cropper.setDragMode();
    }
}

// Events
let onready;
export function addReady(dotNetHelper) {
    if (image) {
        if (onready) {
            console.log("first remove onready");
            removeReady();
        }

        console.log("add onready");

        onready = () => {
            console.log("cropper.cropped");
            console.log(cropper.cropped);
            dotNetHelper.invokeMethodAsync("OnReadyDelegate");
        }
        image.addEventListener('ready', onready);
    }
}
export function removeReady() {
    if (image) {
        console.log("remove onready");

        image.removeEventListener('ready', onready);

        onready = null;
    }
}

let oncropstart;
export function addCropStart(dotNetHelper) {
    if (image) {
        if (oncropstart) {
            console.log("first remove oncropstart");
            removeCropStart();
        }

        console.log("add oncropstart");

        oncropstart = (event) => {
            console.log("event.detail");
            console.log(event.detail);
            dotNetHelper.invokeMethodAsync("OnCropStartDelegate", {
                action: event.detail.action,
                originalEvent: parsePointerEvent(event.detail.originalEvent)
            });
        }
        image.addEventListener('cropstart', oncropstart);
    }
}
export function removeCropStart() {
    if (image) {
        console.log("remove oncropstart");

        image.removeEventListener('cropstart', oncropstart);

        oncropstart = null;
    }
}

let oncropmove;
export function addCropMove(dotNetHelper) {
    if (image) {
        if (oncropmove) {
            console.log("first remove oncropmove");
            removeCropMove();
        }

        console.log("add oncropmove");

        oncropmove = (event) => {
            console.log("event.detail");
            console.log(event.detail);
            dotNetHelper.invokeMethodAsync("OnCropMoveDelegate", {
                action: event.detail.action,
                originalEvent: parsePointerEvent(event.detail.originalEvent)
            });
        }
        image.addEventListener('cropmove', oncropmove);
    }
}
export function removeCropMove() {
    if (image) {
        console.log("remove oncropmove");

        image.removeEventListener('cropmove', oncropmove);

        oncropmove = null;
    }
}

let oncropend;
export function addCropEnd(dotNetHelper) {
    if (image) {
        if (oncropend) {
            console.log("first remove oncropend");
            removeCropEnd();
        }

        console.log("add oncropend");

        oncropend = (event) => {
            console.log("event.detail");
            console.log(event.detail);
            dotNetHelper.invokeMethodAsync("OnCropEndDelegate", {
                action: event.detail.action,
                originalEvent: parsePointerEvent(event.detail.originalEvent)
            });
        }
        image.addEventListener('cropend', oncropend);
    }
}
export function removeCropEnd() {
    if (image) {
        console.log("remove oncropend");

        image.removeEventListener('cropend', oncropend);

        oncropend = null;
    }
}

let oncrop;
export function addCrop(dotNetHelper) {
    if (image) {
        if (oncrop) {
            console.log("first remove oncrop");
            removeCrop();
        }

        console.log("add oncrop");

        oncrop = (event) => {
            console.log("event.detail");
            console.log(event.detail);
            dotNetHelper.invokeMethodAsync("OnCropDelegate", {
                x: event.detail.x,
                y: event.detail.y,
                width: event.detail.width,
                height: event.detail.height,
                rotate: event.detail.rotate,
                scaleX: event.detail.scaleX,
                scaleY: event.detail.scaleY
            });
        }
        image.addEventListener('crop', oncrop);
    }
}
export function removeCrop() {
    if (image) {
        console.log("remove oncrop");

        image.removeEventListener('crop', oncrop);

        oncrop = null;
    }
}

let onzoom;
export function addZoom(dotNetHelper) {
    if (image) {
        if (onzoom) {
            console.log("first remove onzoom");
            removeZoom();
        }

        console.log("add onzoom");

        onzoom = (event) => {
            console.log("event.detail");
            console.log(event.detail);
            dotNetHelper.invokeMethodAsync("OnZoomDelegate", {
                oldRatio: event.detail.oldRatio,
                ratio: event.detail.ratio,
                originalEvent: parseWheelEvent(event.detail.originalEvent)
            });
        }
        image.addEventListener('zoom', onzoom);
    }
}
export function removeZoom() {
    if (image) {
        console.log("remove onzoom");

        image.removeEventListener('zoom', onzoom);

        onzoom = null;
    }
}

function parsePointerEvent(event/*: PointerEvent*/) {
    return {
        ...parseMouseEvent(event),
        pointerId: event.pointerId,
        width: event.width,
        height: event.height,
        pressure: event.pressure,
        tiltX: event.tiltX,
        tiltY: event.tiltY,
        pointerType: event.pointerType,
        isPrimary: event.isPrimary
    };
}

function parseWheelEvent(event/*: WheelEvent*/) {
    return {
        ...parseMouseEvent(event),
        deltaX: event.deltaX,
        deltaY: event.deltaY,
        deltaZ: event.deltaZ,
        deltaMode: event.deltaMode
    };
}

function parseMouseEvent(event/*: MouseEvent*/) {
    return {
        type: event.type,
        detail: event.detail,
        screenX: event.screenX,
        screenY: event.screenY,
        clientX: event.clientX,
        clientY: event.clientY,
        offsetX: event.offsetX,
        offsetY: event.offsetY,
        pageX: event.pageX,
        pageY: event.pageY,
        button: event.button,
        buttons: event.buttons,
        ctrlKey: event.ctrlKey,
        shiftKey: event.shiftKey,
        altKey: event.altKey,
        metaKey: event.metaKey
    };
}
