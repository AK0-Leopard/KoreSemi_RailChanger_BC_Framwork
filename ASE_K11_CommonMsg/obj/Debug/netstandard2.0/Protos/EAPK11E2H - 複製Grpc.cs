// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/EAP_K11_E2H - 複製.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace com.mirle.ibgAK0.EAP.HostMessage.E2H {
  /// <summary>
  /// The greeting service definition.
  /// </summary>
  public static partial class EAP_K11_E2H
  {
    static readonly string __ServiceName = "EAP_K11_E2H";

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

    static readonly grpc::Marshaller<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EP11> __Marshaller_SendHost_EP11 = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EP11.Parser));
    static readonly grpc::Marshaller<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HP11> __Marshaller_Reply_FromHost_HP11 = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HP11.Parser));
    static readonly grpc::Marshaller<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW34> __Marshaller_SendHost_EW34 = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW34.Parser));
    static readonly grpc::Marshaller<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW34> __Marshaller_Reply_FromHost_HW34 = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW34.Parser));
    static readonly grpc::Marshaller<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW35> __Marshaller_SendHost_EW35 = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW35.Parser));
    static readonly grpc::Marshaller<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW35> __Marshaller_Reply_FromHost_HW35 = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW35.Parser));
    static readonly grpc::Marshaller<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW36> __Marshaller_SendHost_EW36 = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW36.Parser));
    static readonly grpc::Marshaller<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW36> __Marshaller_Reply_FromHost_HW36 = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW36.Parser));
    static readonly grpc::Marshaller<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES45> __Marshaller_SendHost_ES45 = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES45.Parser));
    static readonly grpc::Marshaller<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS45> __Marshaller_Reply_FromHost_HS45 = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS45.Parser));
    static readonly grpc::Marshaller<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES46> __Marshaller_SendHost_ES46 = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES46.Parser));
    static readonly grpc::Marshaller<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS46> __Marshaller_Reply_FromHost_HS46 = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS46.Parser));
    static readonly grpc::Marshaller<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES49> __Marshaller_SendHost_ES49 = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES49.Parser));
    static readonly grpc::Marshaller<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS49> __Marshaller_Reply_FromHost_HS49 = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS49.Parser));
    static readonly grpc::Marshaller<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES54> __Marshaller_SendHost_ES54 = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES54.Parser));
    static readonly grpc::Marshaller<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS54> __Marshaller_Reply_FromHost_HS54 = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS54.Parser));

    static readonly grpc::Method<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EP11, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HP11> __Method_SendHost_EP11_Command = new grpc::Method<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EP11, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HP11>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendHost_EP11_Command",
        __Marshaller_SendHost_EP11,
        __Marshaller_Reply_FromHost_HP11);

    static readonly grpc::Method<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW34, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW34> __Method_SendHost_EW34_Command = new grpc::Method<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW34, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW34>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendHost_EW34_Command",
        __Marshaller_SendHost_EW34,
        __Marshaller_Reply_FromHost_HW34);

    static readonly grpc::Method<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW35, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW35> __Method_SendHost_EW35_Command = new grpc::Method<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW35, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW35>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendHost_EW35_Command",
        __Marshaller_SendHost_EW35,
        __Marshaller_Reply_FromHost_HW35);

    static readonly grpc::Method<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW36, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW36> __Method_SendHost_EW36_Command = new grpc::Method<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW36, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW36>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendHost_EW36_Command",
        __Marshaller_SendHost_EW36,
        __Marshaller_Reply_FromHost_HW36);

    static readonly grpc::Method<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES45, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS45> __Method_SendHost_ES45_Command = new grpc::Method<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES45, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS45>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendHost_ES45_Command",
        __Marshaller_SendHost_ES45,
        __Marshaller_Reply_FromHost_HS45);

    static readonly grpc::Method<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES46, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS46> __Method_SendHost_ES46_Command = new grpc::Method<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES46, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS46>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendHost_ES46_Command",
        __Marshaller_SendHost_ES46,
        __Marshaller_Reply_FromHost_HS46);

    static readonly grpc::Method<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES49, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS49> __Method_SendHost_ES49_Command = new grpc::Method<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES49, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS49>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendHost_ES49_Command",
        __Marshaller_SendHost_ES49,
        __Marshaller_Reply_FromHost_HS49);

    static readonly grpc::Method<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES54, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS54> __Method_SendHost_ES54_Command = new grpc::Method<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES54, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS54>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendHost_ES54_Command",
        __Marshaller_SendHost_ES54,
        __Marshaller_Reply_FromHost_HS54);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::com.mirle.ibgAK0.EAP.HostMessage.E2H.EAPK11E2HReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of EAP_K11_E2H</summary>
    [grpc::BindServiceMethod(typeof(EAP_K11_E2H), "BindService")]
    public abstract partial class EAP_K11_E2HBase
    {
      /// <summary>
      ///From EQ (EAP send to MCS)
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      public virtual global::System.Threading.Tasks.Task<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HP11> SendHost_EP11_Command(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EP11 request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW34> SendHost_EW34_Command(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW34 request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW35> SendHost_EW35_Command(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW35 request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW36> SendHost_EW36_Command(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW36 request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS45> SendHost_ES45_Command(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES45 request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS46> SendHost_ES46_Command(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES46 request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS49> SendHost_ES49_Command(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES49 request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS54> SendHost_ES54_Command(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES54 request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for EAP_K11_E2H</summary>
    public partial class EAP_K11_E2HClient : grpc::ClientBase<EAP_K11_E2HClient>
    {
      /// <summary>Creates a new client for EAP_K11_E2H</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public EAP_K11_E2HClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for EAP_K11_E2H that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public EAP_K11_E2HClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected EAP_K11_E2HClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected EAP_K11_E2HClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      /// <summary>
      ///From EQ (EAP send to MCS)
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HP11 SendHost_EP11_Command(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EP11 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendHost_EP11_Command(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      ///From EQ (EAP send to MCS)
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      public virtual global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HP11 SendHost_EP11_Command(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EP11 request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SendHost_EP11_Command, null, options, request);
      }
      /// <summary>
      ///From EQ (EAP send to MCS)
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HP11> SendHost_EP11_CommandAsync(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EP11 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendHost_EP11_CommandAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      ///From EQ (EAP send to MCS)
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      public virtual grpc::AsyncUnaryCall<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HP11> SendHost_EP11_CommandAsync(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EP11 request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SendHost_EP11_Command, null, options, request);
      }
      public virtual global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW34 SendHost_EW34_Command(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW34 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendHost_EW34_Command(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW34 SendHost_EW34_Command(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW34 request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SendHost_EW34_Command, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW34> SendHost_EW34_CommandAsync(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW34 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendHost_EW34_CommandAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW34> SendHost_EW34_CommandAsync(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW34 request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SendHost_EW34_Command, null, options, request);
      }
      public virtual global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW35 SendHost_EW35_Command(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW35 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendHost_EW35_Command(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW35 SendHost_EW35_Command(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW35 request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SendHost_EW35_Command, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW35> SendHost_EW35_CommandAsync(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW35 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendHost_EW35_CommandAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW35> SendHost_EW35_CommandAsync(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW35 request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SendHost_EW35_Command, null, options, request);
      }
      public virtual global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW36 SendHost_EW36_Command(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW36 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendHost_EW36_Command(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW36 SendHost_EW36_Command(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW36 request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SendHost_EW36_Command, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW36> SendHost_EW36_CommandAsync(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW36 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendHost_EW36_CommandAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW36> SendHost_EW36_CommandAsync(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW36 request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SendHost_EW36_Command, null, options, request);
      }
      public virtual global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS45 SendHost_ES45_Command(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES45 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendHost_ES45_Command(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS45 SendHost_ES45_Command(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES45 request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SendHost_ES45_Command, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS45> SendHost_ES45_CommandAsync(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES45 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendHost_ES45_CommandAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS45> SendHost_ES45_CommandAsync(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES45 request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SendHost_ES45_Command, null, options, request);
      }
      public virtual global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS46 SendHost_ES46_Command(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES46 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendHost_ES46_Command(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS46 SendHost_ES46_Command(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES46 request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SendHost_ES46_Command, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS46> SendHost_ES46_CommandAsync(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES46 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendHost_ES46_CommandAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS46> SendHost_ES46_CommandAsync(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES46 request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SendHost_ES46_Command, null, options, request);
      }
      public virtual global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS49 SendHost_ES49_Command(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES49 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendHost_ES49_Command(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS49 SendHost_ES49_Command(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES49 request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SendHost_ES49_Command, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS49> SendHost_ES49_CommandAsync(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES49 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendHost_ES49_CommandAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS49> SendHost_ES49_CommandAsync(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES49 request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SendHost_ES49_Command, null, options, request);
      }
      public virtual global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS54 SendHost_ES54_Command(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES54 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendHost_ES54_Command(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS54 SendHost_ES54_Command(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES54 request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SendHost_ES54_Command, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS54> SendHost_ES54_CommandAsync(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES54 request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendHost_ES54_CommandAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS54> SendHost_ES54_CommandAsync(global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES54 request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SendHost_ES54_Command, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override EAP_K11_E2HClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new EAP_K11_E2HClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(EAP_K11_E2HBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SendHost_EP11_Command, serviceImpl.SendHost_EP11_Command)
          .AddMethod(__Method_SendHost_EW34_Command, serviceImpl.SendHost_EW34_Command)
          .AddMethod(__Method_SendHost_EW35_Command, serviceImpl.SendHost_EW35_Command)
          .AddMethod(__Method_SendHost_EW36_Command, serviceImpl.SendHost_EW36_Command)
          .AddMethod(__Method_SendHost_ES45_Command, serviceImpl.SendHost_ES45_Command)
          .AddMethod(__Method_SendHost_ES46_Command, serviceImpl.SendHost_ES46_Command)
          .AddMethod(__Method_SendHost_ES49_Command, serviceImpl.SendHost_ES49_Command)
          .AddMethod(__Method_SendHost_ES54_Command, serviceImpl.SendHost_ES54_Command).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, EAP_K11_E2HBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_SendHost_EP11_Command, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EP11, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HP11>(serviceImpl.SendHost_EP11_Command));
      serviceBinder.AddMethod(__Method_SendHost_EW34_Command, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW34, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW34>(serviceImpl.SendHost_EW34_Command));
      serviceBinder.AddMethod(__Method_SendHost_EW35_Command, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW35, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW35>(serviceImpl.SendHost_EW35_Command));
      serviceBinder.AddMethod(__Method_SendHost_EW36_Command, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_EW36, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HW36>(serviceImpl.SendHost_EW36_Command));
      serviceBinder.AddMethod(__Method_SendHost_ES45_Command, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES45, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS45>(serviceImpl.SendHost_ES45_Command));
      serviceBinder.AddMethod(__Method_SendHost_ES46_Command, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES46, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS46>(serviceImpl.SendHost_ES46_Command));
      serviceBinder.AddMethod(__Method_SendHost_ES49_Command, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES49, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS49>(serviceImpl.SendHost_ES49_Command));
      serviceBinder.AddMethod(__Method_SendHost_ES54_Command, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::com.mirle.ibgAK0.EAP.HostMessage.E2H.SendHost_ES54, global::com.mirle.ibgAK0.EAP.HostMessage.E2H.Reply_FromHost_HS54>(serviceImpl.SendHost_ES54_Command));
    }

  }
}
#endregion
