// <copyright file="InvalidQuantityException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PlannerEngine.ExceptionStuff;

/// <summary>
/// New Exception class for when there's an invalid amount of items..
/// </summary>
/// <param name="message">string.</param>
public class InvalidQuantityException(string message) : Exception(message);