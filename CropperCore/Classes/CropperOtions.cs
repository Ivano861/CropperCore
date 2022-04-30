using CropperCore.Converters;
using CropperCore.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CropperCore.Classes
{
    public class CropperOtions
    {
        /// <summary>
        /// Define the view mode of the cropper.
        /// If you set viewMode to 0, the crop box can extend outside the canvas, while a value of 1, 2, or 3 will restrict the crop box to the size of the canvas.
        /// ViewMode of 2 or 3 will additionally restrict the canvas to the container.
        /// There is no difference between 2 and 3 when the proportions of the canvas and the container are the same.
        /// </summary>
        //[JsonConverter(typeof(EnumDescriptionConverter<ViewMode>))]
        //[JsonConverter(typeof(int))]
        [JsonPropertyName("viewMode")]
        public ViewMode ViewMode { get; set; }

        /// <summary>
        /// Define the dragging mode of the cropper.
        /// </summary>
        [JsonConverter(typeof(EnumDescriptionConverter<DragMode>))]
        [JsonPropertyName("dragMode")]
        public DragMode DragMode { get; set; } = DragMode.Crop;

        /// <summary>
        /// Define the initial aspect ratio of the crop box. By default, it is the same as the aspect ratio of the canvas (image wrapper).
        /// </summary>
        /// <remarks>
        /// Only available when the AspectRatio option is set to NaN.
        /// </remarks>
        [JsonConverter(typeof(DoubleConverterJSON))]
        [JsonPropertyName("initialAspectRatio")] 
        public double InitialAspectRatio { get; set; } = double.NaN;

        /// <summary>
        /// Define the fixed aspect ratio of the crop box.
        /// By default, the crop box has a free ratio.
        /// </summary>
        [JsonConverter(typeof(DoubleConverterJSON))]
        [JsonPropertyName("aspectRatio")] 
        public double AspectRatio { get; set; } = double.NaN;

        /// <summary>
        /// The previous cropped data you stored will be passed to the SetData method automatically when initialized.
        /// </summary>
        /// <remarks>
        /// Only available when the AutoCrop option had set to the true.
        /// </remarks>
        [JsonPropertyName("data")] 
        public object? Data { get; set; } = null;   // TODO: object? implementare la tipologia corretta

        /// <summary>
        /// Add extra elements (containers) for preview.
        /// </summary>
        /// <remarks>
        /// Notes:
        /// <list type="bullet">
        /// <item>The maximum width is the initial width of the preview container.</item>
        /// <item>The maximum height is the initial height of the preview container.</item>
        /// <item>If you set an aspectRatio option, be sure to set the same aspect ratio to the preview container.</item>
        /// <item>If the preview does not display correctly, set the overflow: hidden style to the preview container.</item>
        /// </list>
        /// </remarks>
        [JsonPropertyName("preview")] 
        public string Preview { get; set; } = "";   // TODO: string implementare la tipologia corretta

        /// <summary>
        /// Re-render the cropper when resizing the window.
        /// </summary>
        [JsonPropertyName("responsive")]
        public bool Responsive { get; set; } = true;

        /// <summary>
        /// Restore the cropped area after resizing the window.
        /// </summary>
        [JsonPropertyName("restore")]
        public bool Restore { get; set; } = true;

        /// <summary>
        /// <para>Check if the current image is a cross-origin image.</para>
        /// <para>If so, a crossOrigin attribute will be added to the cloned image element, and a timestamp parameter will be added to the src attribute to reload the source image to avoid browser cache error.</para>
        /// <para>Adding a crossOrigin attribute to the image element will stop adding a timestamp to the image URL and stop reloading the image.But the request (XMLHttpRequest) to read the image data for orientation checking will require a timestamp to bust cache to avoid browser cache error. You can set the checkOrientation option to false to cancel this request.</para>
        /// <para>If the value of the image's crossOrigin attribute is "use-credentials", then the withCredentials attribute will set to true when read the image data by XMLHttpRequest.</para>
        /// </summary>
        [JsonPropertyName("checkCrossOrigin")]
        public bool CheckCrossOrigin { get; set; } = true;

        /// <summary>
        /// <para>Check the current image's Exif Orientation information. Note that only a JPEG image may contain Exif Orientation information.</para>
        /// <para>Exactly, read the Orientation value for rotating or flipping the image, and then override the Orientation value with 1 (the default value) to avoid some issues (1, 2) on iOS devices.</para>
        /// <para>Requires to set both the rotatable and scalable options to true at the same time.</para>
        /// <para>Note: Do not trust this all the time as some JPG images may have incorrect (non-standard) Orientation values</para>
        /// </summary>
        /// <remarks>
        /// Requires <see href="https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/TypedArray">Typed Arrays</see> support (IE 10+).
        /// </remarks>
        [JsonPropertyName("checkOrientation")]
        public bool CheckOrientation { get; set; } = true;

        /// <summary>
        /// Show the black modal above the image and under the crop box.
        /// </summary>
        [JsonPropertyName("modal")]
        public bool Modal { get; set; } = true;

        /// <summary>
        /// Show the dashed lines above the crop box.
        /// </summary>
        [JsonPropertyName("guides")]
        public bool Guides { get; set; } = true;

        /// <summary>
        /// Show the center indicator above the crop box.
        /// </summary>
        [JsonPropertyName("center")]
        public bool Center { get; set; } = true;

        /// <summary>
        /// Show the white modal above the crop box (highlight the crop box).
        /// </summary>
        [JsonPropertyName("highlight")]
        public bool Highlight { get; set; } = true;

        /// <summary>
        /// Show the grid background of the container.
        /// </summary>
        [JsonPropertyName("background")]
        public bool Background { get; set; } = true;

        /// <summary>
        /// Enable to crop the image automatically when initialized.
        /// </summary>
        [JsonPropertyName("autoCrop")]
        public bool AutoCrop { get; set; } = true;

        /// <summary>
        /// It should be a number between 0 and 1. Define the automatic cropping area size(percentage).
        /// </summary>
        [JsonPropertyName("autoCropArea")]
        public double AutoCropArea { get; set; } = 0.8;

        /// <summary>
        /// Enable to move the image.
        /// </summary>
        [JsonPropertyName("movable")]
        public bool Movable { get; set; } = true;

        /// <summary>
        /// Enable to rotate the image.
        /// </summary>
        [JsonPropertyName("rotatable")]
        public bool Rotatable { get; set; } = true;

        /// <summary>
        /// Enable to scale the image.
        /// </summary>
        [JsonPropertyName("scalable")]
        public bool Scalable { get; set; } = true;

        /// <summary>
        /// Enable to zoom the image.
        /// </summary>
        [JsonPropertyName("zoomable")]
        public bool Zoomable { get; set; } = true;

        /// <summary>
        /// Enable to zoom the image by dragging touch.
        /// </summary>
        [JsonPropertyName("zoomOnTouch")]
        public bool ZoomOnTouch { get; set; } = true;

        /// <summary>
        /// Enable to zoom the image by mouse wheeling.
        /// </summary>
        [JsonPropertyName("zoomOnWheel")]
        public bool ZoomOnWheel { get; set; } = true;

        /// <summary>
        /// Define zoom ratio when zooming the image by mouse wheeling.
        /// </summary>
        [JsonPropertyName("wheelZoomRatio")]
        public double WheelZoomRatio { get; set; } = 0.1;

        /// <summary>
        /// Enable to move the crop box by dragging.
        /// </summary>
        [JsonPropertyName("cropBoxMovable")]
        public bool CropBoxMovable { get; set; } = true;

        /// <summary>
        /// Enable to resize the crop box by dragging.
        /// </summary>
        [JsonPropertyName("cropBoxResizable")]
        public bool CropBoxResizable { get; set; } = true;

        /// <summary>
        /// Enable to toggle drag mode between "crop" and "move" when clicking twice on the cropper.
        /// </summary>
        /// <remarks>
        /// Requires <see href="https://developer.mozilla.org/en-US/docs/Web/Events/dblclick">dblclick</see> event support.
        /// </remarks>
        [JsonPropertyName("toggleDragModeOnDblclick")]
        public bool ToggleDragModeOnDblclick { get; set; } = true;

        /// <summary>
        /// The minimum width of the container.
        /// </summary>
        [JsonPropertyName("minContainerWidth")]
        public int MinContainerWidth { get; set; } = 200;

        /// <summary>
        /// The minimum height of the container.
        /// </summary>
        [JsonPropertyName("minContainerHeight")]
        public int MinContainerHeight { get; set; } = 100;

        /// <summary>
        /// The minimum width of the canvas (image wrapper).
        /// </summary>
        [JsonPropertyName("minCanvasWidth")]
        public int MinCanvasWidth { get; set; } = 0;

        /// <summary>
        /// The minimum height of the canvas (image wrapper).
        /// </summary>
        [JsonPropertyName("minCanvasHeight")]
        public int MinCanvasHeight { get; set; } = 0;

        /// <summary>
        /// The minimum width of the crop box.
        /// <para>Note: This size is relative to the page, not the image.</para>
        /// </summary>
        [JsonPropertyName("minCropBoxWidth")]
        public int MinCropBoxWidth { get; set; } = 0;

        /// <summary>
        /// The minimum height of the crop box.
        /// <para>Note: This size is relative to the page, not the image.</para>
        /// </summary>
        [JsonPropertyName("minCropBoxHeight")]
        public int MinCropBoxHeight { get; set; } = 0;


        /* Di seguito delle funzioni eventualmente da implementare
ready
Type: Function
Default: null
A shortcut of the ready event.

cropstart
Type: Function
Default: null
A shortcut of the cropstart event.

cropmove
Type: Function
Default: null
A shortcut of the cropmove event.

cropend
Type: Function
Default: null
A shortcut of the cropend event.

crop
Type: Function
Default: null
A shortcut of the crop event.

zoom
Type: Function
Default: null
A shortcut of the zoom event.
        */
    }
}
