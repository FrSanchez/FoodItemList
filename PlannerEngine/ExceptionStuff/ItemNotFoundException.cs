// <copyright file="ItemNotFoundException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PlannerEngine.ExceptionStuff;

/// <summary>
/// New Exception class for when item is not found.
/// </summary>
/// <param name="message">string.</param>
public class ItemNotFoundException(string message) : Exception(message);