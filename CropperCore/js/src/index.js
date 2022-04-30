import {
    /*imageJS, */
    createCrop,
    clear,
    crop,
    destroy,
    disable,
    enable,
    move,
    moveTo,
    reset,
    zoom,
    zoomTo,
    rotate,
    rotateTo,
    scale,
    scaleX,
    scaleY,
    getData,
    setData,
    getContainerData,
    getImageData,
    getCanvasData,
    setCanvasData,
    getCropBoxData,
    setCropBoxData,
    getCroppedCanvas,
    getCroppedCanvasHTML,
    setAspectRatio,
    setDragMode,

    // Events
    addReady,
    removeReady,
    addCropStart,
    removeCropStart,
    addCropMove,
    removeCropMove,
    addCropEnd,
    removeCropEnd,
    addCrop,
    removeCrop,
    addZoom,
    removeZoom
} from './image_lib'


export function AddReady(dotNetHelper) {
    addReady(dotNetHelper);
}
export function RemoveReady() {
    removeReady();
}

export function AddCropStart(dotNetHelper) {
    addCropStart(dotNetHelper);
}
export function RemoveCropStart() {
    removeCropStart();
}

export function AddCropMove(dotNetHelper) {
    addCropMove(dotNetHelper);
}
export function RemoveCropMove() {
    removeCropMove();
}

export function AddCropEnd(dotNetHelper) {
    addCropEnd(dotNetHelper);
}
export function RemoveCropEnd() {
    removeCropEnd();
}

export function AddCrop(dotNetHelper) {
    addCrop(dotNetHelper);
}
export function RemoveCrop() {
    removeCrop();
}

export function AddZoom(dotNetHelper) {
    addZoom(dotNetHelper);
}
export function RemoveZoom() {
    removeZoom();
}

export function CreateCrop(img, option, dotNetHelper, events) {
    createCrop(img, option, dotNetHelper, events);
}

export function Crop() {
    crop();
}

export function Reset() {
    reset();
}

export function Clear() {
    clear();
}

export function Enable() {
    enable();
}

export function Disable() {
    disable();
}

export function Destroy() {
    destroy();
}

export function Move(offsetX, offsetY) {
    move(offsetX, offsetY);
}

export function MoveTo(x, y) {
    moveTo(x, y);
}

export function Zoom(ratio) {
    zoom(ratio);
}

export function ZoomTo(ratio, schema) {
    zoomTo(ratio, schema);
}

export function Rotate(degree) {
    rotate(degree);
}

export function RotateTo(degree) {
    rotateTo(degree);
}

export function Scale(scaleX, scaleY) {
    scale(scaleX, scaleY);
}

export function ScaleX(scale) {
    scaleX(scale);
}

export function ScaleY(scale) {
    scaleY(scale);
}

export function GetData(rounded) {
    return getData(rounded);
}

export function SetData(data) {
    return setData(data);
}

export function GetContainerData() {
    return getContainerData();
}

export function GetImageData() {
    return getImageData();
}

export function GetCanvasData() {
    return getCanvasData();
}

export function SetCanvasData(data) {
    setCanvasData(data);
}

export function GetCropBoxData() {
    return getCropBoxData();
}

export function SetCropBoxData(data) {
    setCropBoxData(data);
}

export function GetCroppedCanvas(dest, data) {
    getCroppedCanvas(dest, data);
}

export function GetCroppedCanvasHTML(data) {
    getCroppedCanvasHTML(data);
}

export function SetAspectRatio(aspectRatio) {
    setAspectRatio(aspectRatio);
}

export function SetDragMode(mode) {
    setDragMode(mode);
}
