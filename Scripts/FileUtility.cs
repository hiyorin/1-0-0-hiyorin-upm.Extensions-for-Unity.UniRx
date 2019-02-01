using System;
using System.IO;
using System.Collections;
using UniRx;
using UnityEngine;
using Utility = UnityExtensions.FileUtility;

namespace UnityExtensions.UniRx
{
    public static class FileUtility
    {
        public static IObservable<Unit> SaveAsyncAsObservable(string path, Action<BinaryWriter> onWriter)
        {
            return Observable.Start(() => Utility.Save(path, onWriter));
        }

        public static IObservable<Unit> SaveAsyncAllBytesAsObservable(string path, byte[] bytes)
        {
            return Observable.Start(() => File.WriteAllBytes(Utility.GetFullPath(path), bytes));
        }

        public static IObservable<Unit> SaveAsyncAllTextAsObservable(string path, string contents)
        {
            return Observable.Start(() => File.WriteAllText(Utility.GetFullPath(path), contents));
        }

        public static IObservable<Unit> SaveAsyncAllLinesAsObservable(string path, string[] contents)
        {
            return Observable.Start(() => File.WriteAllLines(Utility.GetFullPath(path), contents));
        }

        public static IEnumerator SaveAsyncAsCoroutine(string path, Action<BinaryWriter> onWriter)
        {
            Exception exception = null;
            yield return SaveAsyncAsObservable(path, onWriter)
                .StartAsCoroutine(result => exception = result);
            if (exception != null)
            {
                throw exception;
            }
        }

        public static IObservable<Unit> LoadAsyncAsObservable(string path, Action<BinaryReader> onReader)
        {
            return Observable.Start(() => Utility.Load(path, onReader));
        }

        public static IObservable<byte[]> LoadAsyncAllBytesAsObservable(string path)
        {
            return Observable.Start(() => File.ReadAllBytes(Utility.GetFullPath(path)));
        }

        public static IObservable<string> LoadAsyncAllTextAsObservable(string path)
        {
            return Observable.Start(() => File.ReadAllText(Utility.GetFullPath(path)));
        }

        public static IObservable<string[]> LoadAsyncAllLinesAsObservable(string path)
        {
            return Observable.Start(() => File.ReadAllLines(Utility.GetFullPath(path)));
        }

        public static IEnumerator LoadAsyncAsCoroutine(string path, Action<BinaryReader> onReader)
        {
            Exception exception = null;
            yield return LoadAsyncAsObservable(path, onReader)
                .StartAsCoroutine(result => exception = result);
            if (exception != null)
            {
                throw exception;
            }
        }

        public static IObservable<byte[]> LoadStreamingAssetsObservable(string path)
        {
            string fullPath = Path.Combine(Application.streamingAssetsPath, path);
            #if UNITY_ANDROID && !UNITY_EDITOR
            return ObservableWWW.GetAndGetBytes(fullPath);
            #else
            return LoadAsyncAllBytesAsObservable(fullPath);
            #endif
        }
    }
}
