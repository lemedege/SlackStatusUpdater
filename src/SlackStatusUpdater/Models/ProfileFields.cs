using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZulipStatusUpdater.Models
{
    public class CustomFields
    {
        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("custom_fields")]
        public List<ProfileField> ProfileFields { get; set; }
    }

    public class ProfileField
    {
        public enum FieldType
        {
            SHORT_TEXT = 1,
            LONG_TEXT = 2,
            LIST_OF_OPTIONS,
            DATE_PICKER,
            LINK,
            PERSON_PICKER,
            EXTERNAL_ACCOUNT,
            PRONOUNS
        }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public FieldType Type { get; set; }

        [JsonProperty("hint")]
        public string Hint { get; set; }

        [JsonProperty("field_data")]
        public String FieldData_str { get; set; }


        [JsonIgnore]
        public List<FieldDataContent> FieldData { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("display_in_profile_summary", NullValueHandling = NullValueHandling.Ignore)]
        public bool? DisplayInProfileSummary { get; set; }

        public string Content { get; set; }

        public ProfileField(string name, int id, int order, FieldType type)
        {
            this.Name = name;
            this.Order = order;
            this.Type = type;
            this.Id = id;
            this.Content = "";
        }
    }

    public class FieldDataContent
    {

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }
    }
}