// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/AGVC_K11_E2H.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace com.mirle.ibgAK0.RGV.HostMessage.E2H {

  /// <summary>Holder for reflection information generated from Protos/AGVC_K11_E2H.proto</summary>
  public static partial class AGVCK11E2HReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/AGVC_K11_E2H.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static AGVCK11E2HReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChlQcm90b3MvQUdWQ19LMTFfRTJILnByb3RvIjAKHVM2RjExX0V2ZW50UmVw",
            "b3J0X1JlcG9ydF9JRF8wEg8KB2VxX25hbWUYASABKAkikgEKHVM2RjExX0V2",
            "ZW50UmVwb3J0X1JlcG9ydF9JRF8xEhIKCmNvbW1hbmRfaWQYASABKAkSEAoI",
            "cHJpb3JpdHkYAiABKAkSDwoHcmVwbGFjZRgDIAEoCRISCgpjYXJyaWVyX2lk",
            "GAQgASgJEhMKC3NvdXJjZV9wb3J0GAUgASgJEhEKCWRlc3RfcG9ydBgGIAEo",
            "CSIlChRTNkYxMl9FdmVudFJlcG9ydEFjaxINCgVhY2tjNhgBIAEoBTLkAgoM",
            "QUdWQ19LMTFfRTJIElAKFVNlbmRTNkYxMV8wMDFfT2ZmbGluZRIeLlM2RjEx",
            "X0V2ZW50UmVwb3J0X1JlcG9ydF9JRF8wGhUuUzZGMTJfRXZlbnRSZXBvcnRB",
            "Y2siABJUChlTZW5kUzZGMTFfMDAyX09ubGluZUxvY2FsEh4uUzZGMTFfRXZl",
            "bnRSZXBvcnRfUmVwb3J0X0lEXzAaFS5TNkYxMl9FdmVudFJlcG9ydEFjayIA",
            "ElUKGlNlbmRTNkYxMV8wMDNfT25saW5lUmVtb3RlEh4uUzZGMTFfRXZlbnRS",
            "ZXBvcnRfUmVwb3J0X0lEXzAaFS5TNkYxMl9FdmVudFJlcG9ydEFjayIAElUK",
            "GlNlbmRTNkYxMV8xMTFfVHJhbnNmZXJyaW5nEh4uUzZGMTFfRXZlbnRSZXBv",
            "cnRfUmVwb3J0X0lEXzEaFS5TNkYxMl9FdmVudFJlcG9ydEFjayIAQieqAiRj",
            "b20ubWlybGUuaWJnQUswLlJHVi5Ib3N0TWVzc2FnZS5FMkhiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0), global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_0.Parser, new[]{ "EqName" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_1), global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F11_EventReport_Report_ID_1.Parser, new[]{ "CommandId", "Priority", "Replace", "CarrierId", "SourcePort", "DestPort" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck), global::com.mirle.ibgAK0.RGV.HostMessage.E2H.S6F12_EventReportAck.Parser, new[]{ "Ackc6" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class S6F11_EventReport_Report_ID_0 : pb::IMessage<S6F11_EventReport_Report_ID_0>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<S6F11_EventReport_Report_ID_0> _parser = new pb::MessageParser<S6F11_EventReport_Report_ID_0>(() => new S6F11_EventReport_Report_ID_0());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<S6F11_EventReport_Report_ID_0> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::com.mirle.ibgAK0.RGV.HostMessage.E2H.AGVCK11E2HReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public S6F11_EventReport_Report_ID_0() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public S6F11_EventReport_Report_ID_0(S6F11_EventReport_Report_ID_0 other) : this() {
      eqName_ = other.eqName_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public S6F11_EventReport_Report_ID_0 Clone() {
      return new S6F11_EventReport_Report_ID_0(this);
    }

    /// <summary>Field number for the "eq_name" field.</summary>
    public const int EqNameFieldNumber = 1;
    private string eqName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string EqName {
      get { return eqName_; }
      set {
        eqName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as S6F11_EventReport_Report_ID_0);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(S6F11_EventReport_Report_ID_0 other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (EqName != other.EqName) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (EqName.Length != 0) hash ^= EqName.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (EqName.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(EqName);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (EqName.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(EqName);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (EqName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(EqName);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(S6F11_EventReport_Report_ID_0 other) {
      if (other == null) {
        return;
      }
      if (other.EqName.Length != 0) {
        EqName = other.EqName;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            EqName = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            EqName = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class S6F11_EventReport_Report_ID_1 : pb::IMessage<S6F11_EventReport_Report_ID_1>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<S6F11_EventReport_Report_ID_1> _parser = new pb::MessageParser<S6F11_EventReport_Report_ID_1>(() => new S6F11_EventReport_Report_ID_1());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<S6F11_EventReport_Report_ID_1> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::com.mirle.ibgAK0.RGV.HostMessage.E2H.AGVCK11E2HReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public S6F11_EventReport_Report_ID_1() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public S6F11_EventReport_Report_ID_1(S6F11_EventReport_Report_ID_1 other) : this() {
      commandId_ = other.commandId_;
      priority_ = other.priority_;
      replace_ = other.replace_;
      carrierId_ = other.carrierId_;
      sourcePort_ = other.sourcePort_;
      destPort_ = other.destPort_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public S6F11_EventReport_Report_ID_1 Clone() {
      return new S6F11_EventReport_Report_ID_1(this);
    }

    /// <summary>Field number for the "command_id" field.</summary>
    public const int CommandIdFieldNumber = 1;
    private string commandId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string CommandId {
      get { return commandId_; }
      set {
        commandId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "priority" field.</summary>
    public const int PriorityFieldNumber = 2;
    private string priority_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Priority {
      get { return priority_; }
      set {
        priority_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "replace" field.</summary>
    public const int ReplaceFieldNumber = 3;
    private string replace_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Replace {
      get { return replace_; }
      set {
        replace_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "carrier_id" field.</summary>
    public const int CarrierIdFieldNumber = 4;
    private string carrierId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string CarrierId {
      get { return carrierId_; }
      set {
        carrierId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "source_port" field.</summary>
    public const int SourcePortFieldNumber = 5;
    private string sourcePort_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string SourcePort {
      get { return sourcePort_; }
      set {
        sourcePort_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "dest_port" field.</summary>
    public const int DestPortFieldNumber = 6;
    private string destPort_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string DestPort {
      get { return destPort_; }
      set {
        destPort_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as S6F11_EventReport_Report_ID_1);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(S6F11_EventReport_Report_ID_1 other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (CommandId != other.CommandId) return false;
      if (Priority != other.Priority) return false;
      if (Replace != other.Replace) return false;
      if (CarrierId != other.CarrierId) return false;
      if (SourcePort != other.SourcePort) return false;
      if (DestPort != other.DestPort) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (CommandId.Length != 0) hash ^= CommandId.GetHashCode();
      if (Priority.Length != 0) hash ^= Priority.GetHashCode();
      if (Replace.Length != 0) hash ^= Replace.GetHashCode();
      if (CarrierId.Length != 0) hash ^= CarrierId.GetHashCode();
      if (SourcePort.Length != 0) hash ^= SourcePort.GetHashCode();
      if (DestPort.Length != 0) hash ^= DestPort.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (CommandId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(CommandId);
      }
      if (Priority.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Priority);
      }
      if (Replace.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Replace);
      }
      if (CarrierId.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(CarrierId);
      }
      if (SourcePort.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(SourcePort);
      }
      if (DestPort.Length != 0) {
        output.WriteRawTag(50);
        output.WriteString(DestPort);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (CommandId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(CommandId);
      }
      if (Priority.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Priority);
      }
      if (Replace.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Replace);
      }
      if (CarrierId.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(CarrierId);
      }
      if (SourcePort.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(SourcePort);
      }
      if (DestPort.Length != 0) {
        output.WriteRawTag(50);
        output.WriteString(DestPort);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (CommandId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(CommandId);
      }
      if (Priority.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Priority);
      }
      if (Replace.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Replace);
      }
      if (CarrierId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(CarrierId);
      }
      if (SourcePort.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(SourcePort);
      }
      if (DestPort.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(DestPort);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(S6F11_EventReport_Report_ID_1 other) {
      if (other == null) {
        return;
      }
      if (other.CommandId.Length != 0) {
        CommandId = other.CommandId;
      }
      if (other.Priority.Length != 0) {
        Priority = other.Priority;
      }
      if (other.Replace.Length != 0) {
        Replace = other.Replace;
      }
      if (other.CarrierId.Length != 0) {
        CarrierId = other.CarrierId;
      }
      if (other.SourcePort.Length != 0) {
        SourcePort = other.SourcePort;
      }
      if (other.DestPort.Length != 0) {
        DestPort = other.DestPort;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            CommandId = input.ReadString();
            break;
          }
          case 18: {
            Priority = input.ReadString();
            break;
          }
          case 26: {
            Replace = input.ReadString();
            break;
          }
          case 34: {
            CarrierId = input.ReadString();
            break;
          }
          case 42: {
            SourcePort = input.ReadString();
            break;
          }
          case 50: {
            DestPort = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            CommandId = input.ReadString();
            break;
          }
          case 18: {
            Priority = input.ReadString();
            break;
          }
          case 26: {
            Replace = input.ReadString();
            break;
          }
          case 34: {
            CarrierId = input.ReadString();
            break;
          }
          case 42: {
            SourcePort = input.ReadString();
            break;
          }
          case 50: {
            DestPort = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class S6F12_EventReportAck : pb::IMessage<S6F12_EventReportAck>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<S6F12_EventReportAck> _parser = new pb::MessageParser<S6F12_EventReportAck>(() => new S6F12_EventReportAck());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<S6F12_EventReportAck> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::com.mirle.ibgAK0.RGV.HostMessage.E2H.AGVCK11E2HReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public S6F12_EventReportAck() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public S6F12_EventReportAck(S6F12_EventReportAck other) : this() {
      ackc6_ = other.ackc6_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public S6F12_EventReportAck Clone() {
      return new S6F12_EventReportAck(this);
    }

    /// <summary>Field number for the "ackc6" field.</summary>
    public const int Ackc6FieldNumber = 1;
    private int ackc6_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Ackc6 {
      get { return ackc6_; }
      set {
        ackc6_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as S6F12_EventReportAck);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(S6F12_EventReportAck other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Ackc6 != other.Ackc6) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Ackc6 != 0) hash ^= Ackc6.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Ackc6 != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Ackc6);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Ackc6 != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Ackc6);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Ackc6 != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Ackc6);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(S6F12_EventReportAck other) {
      if (other == null) {
        return;
      }
      if (other.Ackc6 != 0) {
        Ackc6 = other.Ackc6;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Ackc6 = input.ReadInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            Ackc6 = input.ReadInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code