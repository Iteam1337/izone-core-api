using System;
using System.Collections.Generic;

namespace ica.model
{
    public class SlackResponse
    {
        public string Text { get; set; }
        public string Color
        {
          get
          {
            return Enum.GetName(typeof(SlackColor), SlackColor);
          }
        }
        public SlackColor SlackColor { get; set; }
        public List<SlackResponse> Attachments { get; set;}
  }

  public enum SlackColor
  {
    good = 1,
    warning = 2,
    danger = 3
  }
}
