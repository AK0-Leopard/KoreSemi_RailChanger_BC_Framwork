// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/AGVC_K11_E2H.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace com.mirle.ibgAK0.RGV.HostMessage.E2H {
  /// <summary>
  /// The greeting service definition.
  /// </summary>
  public static partial class AGVC_K11_E2H
  {
    static readonly string __ServiceName = "AGVC_K11_E2H";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0> __Marshaller_S6F11_EventReport_Report_ID_0 = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0.Parser));
    static readonly grpc::Marshaller<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck> __Marshaller_S6F12_EventReportAck = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck.Parser));
    static readonly grpc::Marshaller<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_1> __Marshaller_S6F11_EventReport_Report_ID_1 = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_1.Parser));

    static readonly grpc::Method<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0, global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck> __Method_SendS6F11_001_Offline = new grpc::Method<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0, global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendS6F11_001_Offline",
        __Marshaller_S6F11_EventReport_Report_ID_0,
        __Marshaller_S6F12_EventReportAck);

    static readonly grpc::Method<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0, global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck> __Method_SendS6F11_002_OnlineLocal = new grpc::Method<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0, global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendS6F11_002_OnlineLocal",
        __Marshaller_S6F11_EventReport_Report_ID_0,
        __Marshaller_S6F12_EventReportAck);

    static readonly grpc::Method<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0, global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck> __Method_SendS6F11_003_OnlineRemote = new grpc::Method<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0, global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendS6F11_003_OnlineRemote",
        __Marshaller_S6F11_EventReport_Report_ID_0,
        __Marshaller_S6F12_EventReportAck);

    static readonly grpc::Method<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_1, global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck> __Method_SendS6F11_111_Transferring = new grpc::Method<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_1, global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendS6F11_111_Transferring",
        __Marshaller_S6F11_EventReport_Report_ID_1,
        __Marshaller_S6F12_EventReportAck);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::com.mirle.ibgAK0.RGV.HostMessage.E2H.AGVCK11E2HReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of AGVC_K11_E2H</summary>
    [grpc::BindServiceMethod(typeof(AGVC_K11_E2H), "BindService")]
    public abstract partial class AGVC_K11_E2HBase
    {
      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck> SendS6F11_001_Offline(global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0 request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck> SendS6F11_002_OnlineLocal(global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0 request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck> SendS6F11_003_OnlineRemote(global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0 request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck> SendS6F11_111_Transferring(global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_1 request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for AGVC_K11_E2H</summary>
    public partial class AGVC_K11_E2HClient : grpc::ClientBase<AGVC_K11_E2HClient>
    {
      /// <summary>Creates a new client for AGVC_K11_E2H</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public AGVC_K11_E2HClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for AGVC_K11_E2H that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public AGVC_K11_E2HClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected AGVC_K11_E2HClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected AGVC_K11_E2HClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck SendS6F11_001_Offline(global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendS6F11_001_Offline(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck SendS6F11_001_Offline(global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0 request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SendS6F11_001_Offline, null, options, request);
      }
      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck> SendS6F11_001_OfflineAsync(global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendS6F11_001_OfflineAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Sends a greeting
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck> SendS6F11_001_OfflineAsync(global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0 request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SendS6F11_001_Offline, null, options, request);
      }
      public virtual global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck SendS6F11_002_OnlineLocal(global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendS6F11_002_OnlineLocal(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck SendS6F11_002_OnlineLocal(global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0 request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SendS6F11_002_OnlineLocal, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck> SendS6F11_002_OnlineLocalAsync(global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendS6F11_002_OnlineLocalAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck> SendS6F11_002_OnlineLocalAsync(global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0 request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SendS6F11_002_OnlineLocal, null, options, request);
      }
      public virtual global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck SendS6F11_003_OnlineRemote(global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendS6F11_003_OnlineRemote(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck SendS6F11_003_OnlineRemote(global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0 request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SendS6F11_003_OnlineRemote, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck> SendS6F11_003_OnlineRemoteAsync(global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendS6F11_003_OnlineRemoteAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck> SendS6F11_003_OnlineRemoteAsync(global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0 request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SendS6F11_003_OnlineRemote, null, options, request);
      }
      public virtual global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck SendS6F11_111_Transferring(global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_1 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendS6F11_111_Transferring(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck SendS6F11_111_Transferring(global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_1 request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SendS6F11_111_Transferring, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck> SendS6F11_111_TransferringAsync(global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_1 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendS6F11_111_TransferringAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck> SendS6F11_111_TransferringAsync(global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_1 request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SendS6F11_111_Transferring, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override AGVC_K11_E2HClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new AGVC_K11_E2HClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(AGVC_K11_E2HBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SendS6F11_001_Offline, serviceImpl.SendS6F11_001_Offline)
          .AddMethod(__Method_SendS6F11_002_OnlineLocal, serviceImpl.SendS6F11_002_OnlineLocal)
          .AddMethod(__Method_SendS6F11_003_OnlineRemote, serviceImpl.SendS6F11_003_OnlineRemote)
          .AddMethod(__Method_SendS6F11_111_Transferring, serviceImpl.SendS6F11_111_Transferring).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, AGVC_K11_E2HBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_SendS6F11_001_Offline, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0, global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck>(serviceImpl.SendS6F11_001_Offline));
      serviceBinder.AddMethod(__Method_SendS6F11_002_OnlineLocal, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0, global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck>(serviceImpl.SendS6F11_002_OnlineLocal));
      serviceBinder.AddMethod(__Method_SendS6F11_003_OnlineRemote, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0, global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck>(serviceImpl.SendS6F11_003_OnlineRemote));
      serviceBinder.AddMethod(__Method_SendS6F11_111_Transferring, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_1, global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck>(serviceImpl.SendS6F11_111_Transferring));
    }

  }
}
#endregion
