using System;


namespace TLS
{
  public enum ContentTypeEnum { tls_change_cipher_spec=20,tls_alert=21,tls_handshake=22,tls_application_data=23 };
  public class ContentType
  {
    public ContentTypeEnum value;
    public int num_bytes = 1;

    public int Load(byte[] buffer,int offset) {
      var value = BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes);
      if(Enum.IsDefined(typeof(ContentTypeEnum), value)) {
        this.value = (ContentTypeEnum)value;
      }
      return num_bytes;
    }
  }

  public enum Enum_0Enum { tls_change_cipher_spec=1 };
  public class Enum_0
  {
    public Enum_0Enum value;
    public int num_bytes = 1;

    public int Load(byte[] buffer,int offset) {
      var value = BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes);
      if(Enum.IsDefined(typeof(Enum_0Enum), value)) {
        this.value = (Enum_0Enum)value;
      }
      return num_bytes;
    }
  }

  public enum AlertLevelEnum { tls_warning=1,tls_fatal=2 };
  public class AlertLevel
  {
    public AlertLevelEnum value;
    public int num_bytes = 1;

    public int Load(byte[] buffer,int offset) {
      var value = BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes);
      if(Enum.IsDefined(typeof(AlertLevelEnum), value)) {
        this.value = (AlertLevelEnum)value;
      }
      return num_bytes;
    }
  }

  public enum AlertDescriptionEnum { tls_close_notify=0,tls_unexpected_message=10,tls_bad_record_mac=20,tls_decryption_failed_RESERVED=21,tls_record_overflow=22,tls_decompression_failure=30,tls_handshake_failure=40,tls_no_certificate_RESERVED=41,tls_bad_certificate=42,tls_unsupported_certificate=43,tls_certificate_revoked=44,tls_certificate_expired=45,tls_certificate_unknown=46,tls_illegal_parameter=47,tls_unknown_ca=48,tls_access_denied=49,tls_decode_error=50,tls_decrypt_error=51,tls_export_restriction_RESERVED=60,tls_protocol_version=70,tls_insufficient_security=71,tls_internal_error=80,tls_user_canceled=90,tls_no_renegotiation=100,tls_unsupported_extension=110 };
  public class AlertDescription
  {
    public AlertDescriptionEnum value;
    public int num_bytes = 1;

    public int Load(byte[] buffer,int offset) {
      var value = BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes);
      if(Enum.IsDefined(typeof(AlertDescriptionEnum), value)) {
        this.value = (AlertDescriptionEnum)value;
      }
      return num_bytes;
    }
  }

  public enum HandshakeTypeEnum { tls_hello_request=0,tls_client_hello=1,tls_server_hello=2,tls_certificate=11,tls_server_key_exchange=12,tls_certificate_request=13,tls_server_hello_done=14,tls_certificate_verify=15,tls_client_key_exchange=16,tls_finished=20 };
  public class HandshakeType
  {
    public HandshakeTypeEnum value;
    public int num_bytes = 1;

    public int Load(byte[] buffer,int offset) {
      var value = BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes);
      if(Enum.IsDefined(typeof(HandshakeTypeEnum), value)) {
        this.value = (HandshakeTypeEnum)value;
      }
      return num_bytes;
    }
  }

  public enum CompressionMethodEnum { tls_null=0 };
  public class CompressionMethod
  {
    public CompressionMethodEnum value;
    public int num_bytes = 1;

    public int Load(byte[] buffer,int offset) {
      var value = BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes);
      if(Enum.IsDefined(typeof(CompressionMethodEnum), value)) {
        this.value = (CompressionMethodEnum)value;
      }
      return num_bytes;
    }
  }

  public enum ExtensionTypeEnum { tls_signature_algorithms=13 };
  public class ExtensionType
  {
    public ExtensionTypeEnum value;
    public int num_bytes = 1;

    public int Load(byte[] buffer,int offset) {
      var value = BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes);
      if(Enum.IsDefined(typeof(ExtensionTypeEnum), value)) {
        this.value = (ExtensionTypeEnum)value;
      }
      return num_bytes;
    }
  }

  public enum HashAlgorithmEnum { tls_none=0,tls_md5=1,tls_sha1=2,tls_sha224=3,tls_sha256=4,tls_sha384=5,tls_sha512=6 };
  public class HashAlgorithm
  {
    public HashAlgorithmEnum value;
    public int num_bytes = 1;

    public int Load(byte[] buffer,int offset) {
      var value = BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes);
      if(Enum.IsDefined(typeof(HashAlgorithmEnum), value)) {
        this.value = (HashAlgorithmEnum)value;
      }
      return num_bytes;
    }
  }

  public enum SignatureAlgorithmEnum { tls_anonymous=0,tls_rsa=1,tls_dsa=2,tls_ecdsa=3 };
  public class SignatureAlgorithm
  {
    public SignatureAlgorithmEnum value;
    public int num_bytes = 1;

    public int Load(byte[] buffer,int offset) {
      var value = BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes);
      if(Enum.IsDefined(typeof(SignatureAlgorithmEnum), value)) {
        this.value = (SignatureAlgorithmEnum)value;
      }
      return num_bytes;
    }
  }

  public enum KeyExchangeAlgorithmEnum { tls_dhe_dss=1,tls_dhe_rsa=2,tls_dh_anon=3,tls_rsa=4,tls_dh_dss=5,tls_dh_rsa=6 };
  public class KeyExchangeAlgorithm
  {
    public KeyExchangeAlgorithmEnum value;
    public int num_bytes = 1;

    public int Load(byte[] buffer,int offset) {
      var value = BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes);
      if(Enum.IsDefined(typeof(KeyExchangeAlgorithmEnum), value)) {
        this.value = (KeyExchangeAlgorithmEnum)value;
      }
      return num_bytes;
    }
  }

  public enum ClientCertificateTypeEnum { tls_rsa_sign=1,tls_dss_sign=2,tls_rsa_fixed_dh=3,tls_dss_fixed_dh=4,tls_rsa_ephemeral_dh_RESERVED=5,tls_dss_ephemeral_dh_RESERVED=6,tls_fortezza_dms_RESERVED=20 };
  public class ClientCertificateType
  {
    public ClientCertificateTypeEnum value;
    public int num_bytes = 1;

    public int Load(byte[] buffer,int offset) {
      var value = BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes);
      if(Enum.IsDefined(typeof(ClientCertificateTypeEnum), value)) {
        this.value = (ClientCertificateTypeEnum)value;
      }
      return num_bytes;
    }
  }

  public enum PublicValueEncodingEnum { tls_implicit=1,tls_explicit=2 };
  public class PublicValueEncoding
  {
    public PublicValueEncodingEnum value;
    public int num_bytes = 1;

    public int Load(byte[] buffer,int offset) {
      var value = BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes);
      if(Enum.IsDefined(typeof(PublicValueEncodingEnum), value)) {
        this.value = (PublicValueEncodingEnum)value;
      }
      return num_bytes;
    }
  }

}
