using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using BusinessObjects;
namespace DataObjects
{
    public class AppointmentConverter : JsonConverter<Appointment>
    {
        public override Appointment Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            var root = doc.RootElement;
            var kindString = root.GetProperty("Kind").GetString();
            var kind = Enum.Parse<AppointmentKind>(kindString);
            var rawText = root.GetRawText();
            switch (kind)
            {
                case AppointmentKind.Injection:
                    return JsonSerializer.Deserialize<InjectionAppointment>(rawText, options);
                case AppointmentKind.Pills:
                    return JsonSerializer.Deserialize<PillsAppointment>(rawText, options);
                case AppointmentKind.Diagnostic:
                    return JsonSerializer.Deserialize<DiagnosticAppointment>(rawText, options);
                default:
                    throw new Exception("Неизвестный тип назначения");
            }
        }
        public override void Write(Utf8JsonWriter writer, Appointment value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}