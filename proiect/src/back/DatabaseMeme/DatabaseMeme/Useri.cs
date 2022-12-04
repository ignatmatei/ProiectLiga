using System;
using System.Collections.Generic;

namespace DatabaseMeme;

public partial class Useri
{
    public long Id { get; set; }

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Meme> Memes { get; } = new List<Meme>();
}
