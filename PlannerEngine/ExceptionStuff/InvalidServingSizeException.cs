// <copyright file="InvalidServingSizeException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PlannerEngine.ExceptionStuff;

/// <summary>
/// New Exception class for invalid serving size.
/// </summary>
/// <param name="message">string.</param>
public class InvalidServingSizeException(string message) : Exception(message);