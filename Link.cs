using System;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using OpenGloves_Unity.Data;
using OpenGloves_Unity.Extensions;
using OpenGloves_Unity.Logging;

namespace OpenGloves_Unity
{
    public class Link : IDisposable
    {
        public NamedPipeClientStream PipeStream { get; private set; }
        public const string PipeName = @"vrapplication\ffb\curl\";
        public const int Timeout = 10;

        public Link(Handedness handedness)
        {
            var handstr = handedness.HandednessToString();
            PipeStream = new NamedPipeClientStream($"{PipeName}{handstr}");
            Log.OpenGlovesLogger.Info($"Connecting to hand pipe for {handstr} hand... ({Timeout}s timeout)");

            try
            {
                PipeStream.Connect(Timeout * 1000);
            }
            catch (Exception e)
            {
                Log.OpenGlovesLogger.Error($"Connection to hand pipe for {handstr} failed with exception: {e}");
            }

            Log.OpenGlovesLogger.Info(PipeStream.IsConnected
                ? $"Connected to hand pipe for {handstr}."
                : $"Failed connection to hand pipe for {handstr}");
        }

        public void Relax() => WriteInput(new Input());

        public void WriteInput(Input input)
        {
            #if DEBUG
            Log.OpenGlovesLogger.Debug($"Thumb: {input.ThumbCurl} Index: {input.IndexCurl} Middle: {input.MiddleCurl} Ring: {input.RingCurl} Pinky: {input.PinkyCurl}");
            #endif

            if (!PipeStream.IsConnected)
                return;

            var size = Marshal.SizeOf(input);
            var bytes = new byte[size];

            var pointer = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(input, pointer, true);
            Marshal.Copy(pointer, bytes, 0, size);
            Marshal.FreeHGlobal(pointer);

            PipeStream.Write(bytes, 0, size);
        }

        public void Dispose()
        {
            PipeStream?.Dispose();
        }
    }
}