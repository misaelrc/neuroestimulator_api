﻿namespace NeuroEstimulator.Framework.Database.EfCore.Interface;

public interface IBaseEntity<TKey>
{
    TKey Id { get; }
}