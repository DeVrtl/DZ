using System;
using UnityEngine;

public class AnimatioHandler : IDisposable
{
    private Animator _animator;
    private bool _disposed = false;

    public AnimatioHandler(Animator animator)
    {
        _animator = animator;
        _animator.SetBool("IsAnimating", true);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~AnimatioHandler()
    {
        Dispose(false);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _animator.SetBool("IsAnimating", false);
            }
            _disposed = true;
        }
    }
}
