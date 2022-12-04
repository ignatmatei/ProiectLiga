using System;
using System.Collections.Generic;

namespace DatabaseMeme;

public partial class Meme
{
    public long Id { get; set; }

    public long IdUser { get; set; }

    public string Description { get; set; } = null!;

    public virtual Useri IdUserNavigation { get; set; } = null!;
}
