using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace CropperCore.Enumerates
{
    public enum ViewMode
    {
        /// <summary>
        /// no restrictions.
        /// </summary>
        NoRestriction = 0,

        /// <summary>
        /// restrict the crop box not to exceed the size of the canvas.
        /// </summary>
        RestrictCrop = 1,

        /// <summary>
        /// restrict the minimum canvas size to fit within the container.
        /// If the proportions of the canvas and the container differ,
        /// the minimum canvas will be surrounded by extra space in one of the dimensions.
        /// </summary>
        RestrictFit = 2,

        /// <summary>
        /// restrict the minimum canvas size to fill fit the container.
        /// If the proportions of the canvas and the container are different,
        /// the container will not be able to fit the whole canvas in one of the dimensions.
        /// </summary>
        RestrictFillFit = 3,
    }

    public enum DragMode
    {
        /// <summary>
        /// create a new crop box.
        /// </summary>
        [Description("crop")] Crop,

        /// <summary>
        /// move the canvas
        /// </summary>
        [Description("move")] Move,

        /// <summary>
        /// do nothing
        /// </summary>
        [Description("none")] None,
    }

    public enum ImageSmoothingQuality
    {
        /// <summary>
        /// quality low
        /// </summary>
        [Description("low")] Low,

        /// <summary>
        /// quality medium
        /// </summary>
        [Description("medium")] Medium,

        /// <summary>
        /// quality high
        /// </summary>
        [Description("high")] High,
    }
}
