﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace HospitalManagement.Blazor.Services
{
    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        private readonly string _format = "yyyy-MM-dd";
        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => DateOnly.ParseExact(reader.GetString()!, _format, null);

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(_format));
    }

    public class NullableDateOnlyJsonConverter : JsonConverter<DateOnly?>
    {
        private readonly string _format = "yyyy-MM-dd";
        public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => string.IsNullOrEmpty(reader.GetString()) ? null : DateOnly.ParseExact(reader.GetString()!, _format, null);

        public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
            => writer.WriteStringValue(value?.ToString(_format));
    }
}
