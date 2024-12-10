using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace CApp.Models;

[Table("users")]

//connecting to supabase- for users
public class User : BaseModel
{
    [PrimaryKey("id", false)]
    public int Id { get; set; }

    [Column("email")]
    public string Email1 { get; set; }

    [Column("password")]
    public string Password1 { get; set; }

    [Column("created_at", ignoreOnInsert: true)]
    public DateTime CreatedAt { get; set; }

}
