using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ChatGpt
    {
        public ChatGpt(string prompt)
        {
            this.prompt = $"me responda estritamente apenas com o valor da resposta, desconsiderando a margem de erro, em uma escala de 0 a 100, o quão dificil é{prompt}?";
            //this.prompt = $"{prompt}?";
            this.model = "text-davinci-003";
            this.max_tokens = 100;
            this.temperature = 0.6m;
        }
        public string model { get; set; }
        public string prompt { get; set; }
        public int max_tokens { get; set; }
        public decimal temperature { get; set; }
    }

    public class Score
    {
        public string prompt { get; set; }
    }

    public class Choice
    {
        public string text { get; set; }
        public int index { get; set; }
        public object logprobs { get; set; }
        public string finish_reason { get; set; }
    }

    public class ResponseGpt
    {
        public string id { get; set; }
        public string @object { get; set; }
        public int created { get; set; }
        public string model { get; set; }
        public List<Choice> choices { get; set; }
        public Usage usage { get; set; }
    }

    public class Usage
    {
        public int prompt_tokens { get; set; }
        public int completion_tokens { get; set; }
        public int total_tokens { get; set; }
    }
}