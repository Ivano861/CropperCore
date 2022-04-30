using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CropperCore.Converters
{
    public class DoubleConverterJSON : JsonConverter<double>
    {
        public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                if (reader.GetString() == "NaN")
                {
                    return double.NaN;
                }
                else if (reader.GetString() == "Infinity")
                {
                    return double.PositiveInfinity;
                }
                else if (reader.GetString() == "-Infinity")
                {
                    return double.NegativeInfinity;
                }
                else
                {
                    return double.NaN;
                }
            }

            return reader.GetDouble(); // JsonException thrown if reader.TokenType != JsonTokenType.Number
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            if (double.IsNaN(value))
            {
                writer.WriteStringValue("NaN");
            }
            else if (double.IsPositiveInfinity(value))
            {
                writer.WriteStringValue("Infinity");
            }
            else if (double.IsNegativeInfinity(value))
            {
                writer.WriteStringValue("-Infinity");
            }
            else
            {
                writer.WriteNumberValue(value);
            }
        }
    }
}
