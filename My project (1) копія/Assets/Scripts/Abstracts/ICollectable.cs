using System;
public interface ICollectable 
{
    void Initialize(Action onCollect, Action onNotCollect);
    void Collect();
    void OnNotCollect();
}

