import Cropper from "cropperjs";

let cr_list = new Map<string, CropperElement>();

class CropperElement {
    private cropper: Cropper;
    private image: HTMLImageElement | HTMLCanvasElement;

    // Events
    public onready: (event: Cropper.CropperEvent) => void;
    public oncropstart: (event: Cropper.CropStartEvent) => void;
    public oncropmove: (event: Cropper.CropMoveEvent) => void;
    public oncropend: (event: Cropper.CropEndEvent) => void;
    public oncrop: (event: Cropper.CropEvent) => void;
    public onzoom: (event: Cropper.ZoomEvent) => void;

    constructor(img: string | HTMLImageElement | HTMLCanvasElement, option: Cropper.Options, dotNetHelper: DotNet.DotNetObject) {
        if (!img) {
            throw "img is not defined";
        }

        if (!dotNetHelper) {
            throw "dotNetHelper is required";
        }

        if (typeof img === 'string') {
            let i = document.getElementById(img);
            if (i instanceof HTMLCanvasElement || i instanceof HTMLImageElement) {
                this.image = i;
            }
            else {
                throw "img is not a HTMLCanvasElement or a HTMLImageElement";
            }
        }
        else {
            this.image = img;
        }

        this.onready = (event) => this.addInternalReadyEvent(dotNetHelper, event);
        this.image.addEventListener('ready', this.onready);

        this.oncropstart = (event) => this.addInternalCropStartEvent(dotNetHelper, event);
        this.image.addEventListener('cropstart', this.oncropstart);

        this.oncropmove = (event) => this.addInternalCropMoveEvent(dotNetHelper, event);
        this.image.addEventListener('cropmove', this.oncropmove);

        this.oncropend = (event) => this.addInternalCropEndEvent(dotNetHelper, event);
        this.image.addEventListener('cropend', this.oncropend);

        this.oncrop = (event) => this.addInternalCropEvent(dotNetHelper, event);
        this.image.addEventListener('crop', this.oncrop);

        this.onzoom = (event) => this.addInternalZoomEvent(dotNetHelper, event);
        this.image.addEventListener('zoom', this.onzoom);

        if (this.image instanceof HTMLCanvasElement)
            this.cropper = new Cropper(this.image, option);
        else
            this.cropper = new Cropper(this.image, option);
    }

    addInternalReadyEvent = (dotNetHelper: DotNet.DotNetObject, event: Cropper.ReadyEvent<EventTarget>) => {
        //console.log("console.log(event): " + event);
        //console.log(event);
        dotNetHelper.invokeMethodAsync("OnReadyCallback");
    }

    addInternalCropStartEvent = (dotNetHelper: DotNet.DotNetObject, event: Cropper.CropStartEvent) => {
        if ((event.detail.originalEvent instanceof PointerEvent)) {
            dotNetHelper.invokeMethodAsync("OnCropStartPointerCallback", {
                action: event.detail.action,
                originalEvent: parsePointerEvent(event.detail.originalEvent)
            });
        }
        //else if ((event.detail.originalEvent instanceof MouseEvent)) {
        //    dotNetHelper.invokeMethodAsync("OnCropStartMouseCallback", {
        //        action: event.detail.action,
        //        originalEvent: parseMouseEvent(event.detail.originalEvent)
        //    });
        //}
        else if ((event.detail.originalEvent instanceof TouchEvent)) {
            dotNetHelper.invokeMethodAsync("OnCropStartTouchCallback", {
                action: event.detail.action,
                originalEvent: parseTouchEvent(event.detail.originalEvent)
            });
        }
    }

    addInternalCropMoveEvent = (dotNetHelper: DotNet.DotNetObject, event: Cropper.CropMoveEvent) => {
        if ((event.detail.originalEvent instanceof PointerEvent)) {
            dotNetHelper.invokeMethodAsync("OnCropMovePonterCallback", {
                action: event.detail.action,
                originalEvent: parsePointerEvent(event.detail.originalEvent)
            });
        }
        //else if ((event.detail.originalEvent instanceof MouseEvent)) {
        //    dotNetHelper.invokeMethodAsync("OnCropMoveMouseCallback", {
        //        action: event.detail.action,
        //        originalEvent: parseMouseEvent(event.detail.originalEvent)
        //    });
        //}
        else if ((event.detail.originalEvent instanceof TouchEvent)) {
            dotNetHelper.invokeMethodAsync("OnCropMoveTouchCallback", {
                action: event.detail.action,
                originalEvent: parseTouchEvent(event.detail.originalEvent)
            });
        }
    }

    addInternalCropEndEvent = (dotNetHelper: DotNet.DotNetObject, event: Cropper.CropEndEvent) => {
        if ((event.detail.originalEvent instanceof PointerEvent)) {
            if (event.detail.originalEvent.type === 'pointerup') {
                dotNetHelper.invokeMethodAsync("OnCropEndPointerCallback", {
                    action: event.detail.action,
                    originalEvent: parsePointerEvent(event.detail.originalEvent)
                });
            }
            else if (event.detail.originalEvent.type === 'pointercancel') {
                dotNetHelper.invokeMethodAsync("OnCropEndPointerCancelCallback", {
                    action: event.detail.action,
                    originalEvent: parsePointerEvent(event.detail.originalEvent)
                });
            }
        }
        //else if ((event.detail.originalEvent instanceof MouseEvent)) {
        //    dotNetHelper.invokeMethodAsync("OnCropEndMouseCallback", {
        //        action: event.detail.action,
        //        originalEvent: parseMouseEvent(event.detail.originalEvent)
        //    });
        //}
        else if ((event.detail.originalEvent instanceof TouchEvent)) {
            if (event.detail.originalEvent.type === 'touchend') {
                dotNetHelper.invokeMethodAsync("OnCropEndTouchCallback", {
                    action: event.detail.action,
                    originalEvent: parseTouchEvent(event.detail.originalEvent)
                });
            }
            else if (event.detail.originalEvent.type === 'touchcancel') {
                dotNetHelper.invokeMethodAsync("OnCropEndTouchCancelCallback", {
                    action: event.detail.action,
                    originalEvent: parseTouchEvent(event.detail.originalEvent)
                });
            }
        }
    }

    addInternalCropEvent = (dotNetHelper: DotNet.DotNetObject, event: Cropper.CropEvent) => {
        dotNetHelper.invokeMethodAsync("OnCropCallback", {
            x: event.detail.x,
            y: event.detail.y,
            width: event.detail.width,
            height: event.detail.height,
            rotate: event.detail.rotate,
            scaleX: event.detail.scaleX,
            scaleY: event.detail.scaleY
        });
    }

    addInternalZoomEvent = (dotNetHelper: DotNet.DotNetObject, event: Cropper.ZoomEvent) => {
        let response: boolean = true;
        if ((event.detail.originalEvent instanceof PointerEvent)) {
            response = dotNetHelper.invokeMethod<boolean>("OnZoomPointerCallback", {
                oldRatio: event.detail.oldRatio,
                ratio: event.detail.ratio,
                originalEvent: parsePointerEvent(event.detail.originalEvent)
            });
        }
        else if ((event.detail.originalEvent instanceof WheelEvent)) {
            response = dotNetHelper.invokeMethod<boolean>("OnZoomWheelCallback", {
                oldRatio: event.detail.oldRatio,
                ratio: event.detail.ratio,
                originalEvent: parseWheelEvent(event.detail.originalEvent)
            });
        }
        //else if ((event.detail.originalEvent instanceof MouseEvent)) {
        //    response = dotNetHelper.invokeMethod<boolean>("OnZoomMouseCallback", {
        //        oldRatio: event.detail.oldRatio,
        //        ratio: event.detail.ratio,
        //        originalEvent: parseMouseEvent(event.detail.originalEvent)
        //    });
        //}
        else if ((event.detail.originalEvent instanceof TouchEvent)) {
            response = dotNetHelper.invokeMethod<boolean>("OnZoomTouchCallback", {
                oldRatio: event.detail.oldRatio,
                ratio: event.detail.ratio,
                originalEvent: parseTouchEvent(event.detail.originalEvent)
            });
        }
        else {
            response = dotNetHelper.invokeMethod<boolean>("OnZoomCommandCallback", {
                oldRatio: event.detail.oldRatio,
                ratio: event.detail.ratio,
                originalEvent: parseEvent()
            });
        }

        if (!response) {
            console.log("Annulliamo ...")
            event.preventDefault();
        }
    }

    getCropper(): Cropper {
        return this.cropper;
    };

    getImage(): HTMLImageElement | HTMLCanvasElement {
        return this.image;
    };

    destroy(): void {
        if (this.onready) {
            this.image.removeEventListener('ready', this.onready);
        }
        if (this.oncropstart) {
            this.image.removeEventListener('cropstart', this.oncropstart);
        }
        if (this.oncropmove) {
            this.image.removeEventListener('cropmove', this.oncropmove);
        }
        if (this.oncropend) {
            this.image.removeEventListener('cropend', this.oncropend);
        }
        if (this.oncrop) {
            this.image.removeEventListener('crop', this.oncrop);
        }
        if (this.onzoom) {
            this.image.removeEventListener('zoom', this.onzoom);
        }
        if (this.cropper) {
            this.cropper.destroy();
        }
    }
}


function getCropperElement(name?: string): CropperElement {
    let nameElement: string;

    if (name === undefined || name === null) {
        nameElement = "default";
    }
    else {
        nameElement = name;
    }
    if (cr_list.has(nameElement)) {
        return cr_list.get(nameElement);
    }

    throw `Cropper ${name ?? ""} not found`;
}

function getCropper(name?: string): Cropper {
    let nameElement: string;

    if (name === undefined || name === null) {
        nameElement = "default";
    }
    else {
        nameElement = name;
    }
    if (cr_list.has(nameElement)) {
        return cr_list.get(nameElement).getCropper();
    }

    throw `Cropper ${name ?? ""} not found`;
}

function getImage(name?: string): HTMLImageElement | HTMLCanvasElement {
    let nameElement: string;

    if (name === undefined || name === null) {
        nameElement = "default";
    }
    else {
        nameElement = name;
    }
    if (cr_list.has(nameElement)) {
        return cr_list.get(nameElement).getImage();
    }

    throw `Cropper ${name ?? ""} not found`;
}


export function create(img: string | HTMLImageElement | HTMLCanvasElement, option: Cropper.Options, dotNetHelper: DotNet.DotNetObject, name?: string) {
    if (name === undefined || name === null) {
        name = "default";
    }

    console.log(cr_list);

    if (cr_list.has(name)) {
        let element = cr_list.get(name);
        element.destroy();
        cr_list.delete(name);
    }
    cr_list.set(name, new CropperElement(img, option, dotNetHelper));
}

export function crop(name?: string) {
    getCropper(name).crop();
}

export function reset(name?: string) {
    getCropper(name).reset();
}

export function clear(name?: string) {
    getCropper(name).clear();
}

export function enable(name?: string) {
    getCropper(name).enable();
}

export function disable(name?: string) {
    getCropper(name).disable();
}

export function destroy(name?: string) {
    getCropperElement(name).destroy();
    cr_list.delete(name);
}

export function move(offsetX: number, offsetY?: number, name?: string) {
    if (offsetY === null || offsetY === undefined) {
        getCropper(name).move(offsetX);
    }
    else {
        getCropper(name).move(offsetX, offsetY);
    }
}

export function moveTo(x: number, y?: number, name?: string) {
    if (y === null || y === undefined) {
        getCropper(name).moveTo(x);
    }
    else {
        getCropper(name).moveTo(x, y);
    }
}

export function zoom(ratio: number, name?: string) {
    getCropper(name).zoom(ratio);
}

export function zoomTo(ratio: number, schema?: { x: number, y: number }, name?: string) {
    if (schema) {
        getCropper(name).zoomTo(ratio, schema);
    }
    else {
        getCropper(name).zoomTo(ratio);
    }
}

export function rotate(degree: number, name?: string) {
    getCropper(name).rotate(degree);
}

export function rotateTo(degree: number, name?: string) {
    getCropper(name).rotateTo(degree);
}

export function scale(scaleX: number, scaleY?: number, name?: string) {
    if (scaleY) {
        getCropper(name).scale(scaleX, scaleY);
    }
    else {
        getCropper(name).scale(scaleX);
    }
}

export function scaleX(scaleX: number, name?: string) {
    getCropper(name).scaleX(scaleX);
}

export function scaleY(scaleY: number, name?: string) {
    getCropper(name).scaleY(scaleY);
}

export function getData(rounded: boolean, name?: string): Cropper.Data {
    if (rounded) {
        return getCropper(name).getData(rounded);
    }
    else {
        return getCropper(name).getData();
    }
}

export function setData(data: Cropper.SetDataOptions, name?: string) {
    getCropper(name).setData(data);
}

export function getContainerData(name?: string): Cropper.ContainerData {
    return getCropper(name).getContainerData();
}

export function getImageData(name?: string): Cropper.ImageData {
    return getCropper(name).getImageData();
}

export function getCanvasData(name?: string): Cropper.CanvasData {
    return getCropper(name).getCanvasData();
}

export function setCanvasData(data: Cropper.SetCanvasDataOptions, name?: string) {
    getCropper(name).setCanvasData(data);
}

export function getCropBoxData(name?: string): Cropper.CropBoxData {
    return getCropper(name).getCropBoxData();
}

export function setCropBoxData(data: Cropper.SetCropBoxDataOptions, name?: string) {
    getCropper(name).setCropBoxData(data);
}

export function getCroppedCanvas(dest: string | HTMLImageElement, options: Cropper.GetCroppedCanvasOptions, name?: string) {
    let imgDest: HTMLImageElement;

    if (!dest) {
        throw "htmlimage or name required";
    }

    if (typeof dest === 'string') {
        imgDest = document.getElementById(dest) as HTMLImageElement;
    }
    else {
        imgDest = dest;
    }

    imgDest.setAttribute("src", getCropper(name).getCroppedCanvas(options).toDataURL("image/jpeg"));
}
export function getCroppedCanvasHTML(options: Cropper.GetCroppedCanvasOptions, name?: string): HTMLCanvasElement {
    return getCropper(name).getCroppedCanvas(options);
}

export function setAspectRatio(aspectRatio: number, name?: string) {
    getCropper(name).setAspectRatio(aspectRatio);
}

export function setDragMode(mode: Cropper.DragMode, name?: string) {
    console.log(mode);
    getCropper(name).setDragMode(mode);
}

// Events
function parseEvent() {
    return {}
}

function parsePointerEvent(event: PointerEvent) {
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

function parseWheelEvent(event: WheelEvent) {
    return {
        ...parseMouseEvent(event),
        deltaX: event.deltaX,
        deltaY: event.deltaY,
        deltaZ: event.deltaZ,
        deltaMode: event.deltaMode
    };
}

function parseMouseEvent(event: MouseEvent) {
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

function parseTouchEvent(event: TouchEvent) {
    return {
        type: event.type,
        detail: event.detail,
        touches: parseTouch(event.touches),
        targetTouches: parseTouch(event.targetTouches),
        changedTouches: parseTouch(event.changedTouches),
        ctrlKey: event.ctrlKey,
        shiftKey: event.shiftKey,
        altKey: event.altKey,
        metaKey: event.metaKey
    };
}

function parseTouch(touchList: TouchList) {
    const touches: UITouchPoint[] = [];
    for (let i = 0; i < touchList.length; i++) {
        const touch = touchList[i];
        touches.push({
            identifier: touch.identifier,
            clientX: touch.clientX,
            clientY: touch.clientY,
            screenX: touch.screenX,
            screenY: touch.screenY,
            pageX: touch.pageX,
            pageY: touch.pageY
        });
    }
    return touches;
}

interface UITouchPoint {
    identifier: number;
    screenX: number;
    screenY: number;
    clientX: number;
    clientY: number;
    pageX: number;
    pageY: number;
}
