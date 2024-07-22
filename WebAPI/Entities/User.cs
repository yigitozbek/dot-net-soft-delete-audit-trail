using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Base;

namespace WebAPI.Entities;

/// <summary>
///     Represents a user in the system.
/// </summary>
public sealed class User : FullyAuditedEntity<Guid>
{
    /// <summary>
    ///     The username of the user.
    /// </summary>
    [StringLength(200)]
    [Column(TypeName = "varchar(200)")]
    public string Username { get; set; } = string.Empty;

    
    /// <summary>
    ///     The name of the user.
    /// </summary>
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;
    
    
    /// <summary>
    ///     The surname of the user.
    /// </summary>
    [StringLength(200)]
    public string Surname { get; set; } = string.Empty;
    
    /// <summary>
    ///     The email of the user.
    /// </summary>
    [StringLength(30)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;
    
    /// <summary>
    ///     The password salt of the user.
    /// </summary>
    [Required]
    public byte[] PasswordSalt { get; set; } = null!;

    /// <summary>
    ///     The password hash of the user.
    /// </summary>
    [Required]
    public byte[] PasswordHash { get; set; } = null!;

    /// <summary>
    ///     The user's role.
    /// </summary>
    [DefaultValue(true)]
    public bool IsActive { get; set; } = true;
}