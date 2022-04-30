using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CropperCore.Converters
{
    public class EnumDescriptionConverter<T> : JsonConverter<T> where T : Enum
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotSupportedException();
        }
        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var description = fieldInfo?.GetCustomAttribute(typeof(DescriptionAttribute), false) as DescriptionAttribute ?? DescriptionAttribute.Default;
            writer.WriteStringValue(description?.Description);
        }
    }
}
