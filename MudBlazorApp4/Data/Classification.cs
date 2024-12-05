// **********************************************************************************************************************
// Module Name      - Classification.cs
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

[Table("classifications")]
public class Classification
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required int ClassificationCd { get; set; }

    public required string ClassificationName { get; set; }
}