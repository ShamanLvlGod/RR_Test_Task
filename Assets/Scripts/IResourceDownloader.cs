using System;
using System.Collections;
using Utils;

public interface IResourceDownloader
{
    YieldTask GetLoadingTask();
}