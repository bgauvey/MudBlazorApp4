// **********************************************************************************************************************
// Module Name      - Registry.cs
// Description      -
// Author	        -  Bill Gauvey
// Date Created	    - 11/30/2024
// Version	        - 1.0.0
// 
// Copyright (C) 2024 Top Livestock Company.  All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
// Notes            -
// ---------------------------------------------------------------------------------------------------------------------
// Date_Modified      Modified_By      Version      Changes
// 
// ---------------------------------------------------------------------------------------------------------------------
// *********************************************************************************************************************

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TLC.Registry.Data;

public class Registry
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required int RegistrationId { get; set; }

    public required string RegistrationNumber { get; set; }

    public required string Name { get; set; }

    public required Classification Classification { get; set; }

    public Breeder? Breeder { get; set; }

    public required string Sex { get; set; }

    public string? Bloodline { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public int? BirthRank { get; set; }

    public string? TagNumber { get; set; }

    public required DnaStatus DnaStatus { get; set; }

    public string? BDI { get; set; }

    public string? MicroChip { get; set; }

    public string? Color { get; set; }

    public string? TattooLeft { get; set; }

    public string? TattooRight { get; set; }

    [Column("sire_registration_id")]
    [ForeignKey("RegistrationId")]
    public int? Sire { get; set; }

    [Column("dam_registration_id")]
    [ForeignKey("RegistrationId")]
    public int? Dam { get; set; }

    public float? BirthWeight { get; set; }

    public float? ThirtyDayWeight { get; set; }
}