// **********************************************************************************************************************
// Module Name      - Breeder.cs
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

namespace TLC.Registry.Client.Models;

public class Breeder
{
    public int BreederId { get; set; }

    public required string Name { get; set; }

    public string? FarmName { get; set; }

    public string EmailAddress { get; set; }

    public string? Phone { get; set; }

    public required string AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public required string City { get; set; }

    public required string State { get; set; }

    public required string Zip { get; set; }

    public string? HerdPrefix { get; set; }
}