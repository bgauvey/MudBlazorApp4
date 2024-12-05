// **********************************************************************************************************************
// Module Name      - IBreederService.cs
// Description      -
// Author	        -  Bill Gauvey
// Date Created	    - 12/01/2024
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

using Microsoft.AspNetCore.Mvc;
using TLC.Registry.Data;

namespace TLC.Registry.Contracts;

public interface IBreederService
{
    Task<IEnumerable<Breeder>> GetBreeders();
    Task<Breeder> GetBreeder(int id);
    Task PutBreeder(int id, Breeder breeder);
    Task<Breeder> PostBreeder(Breeder breeder);
    Task DeleteBreeder(int id);
}