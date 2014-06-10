// This code was generated by a tool. Please modify with caution.
//

using System;

namespace TLS
{
  public enum ContentTypeEnum { tls_change_cipher_spec=20,tls_alert=21,tls_handshake=22,tls_application_data=23 };
  public class ContentType
  {
    public ContentTypeEnum value;
    public int num_bytes = 1;

    public int Load(byte[] buffer,long offset) {
      long value;
      BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes,out value);
      if(Enum.IsDefined(typeof(ContentTypeEnum), value)) {
        this.value = (ContentTypeEnum)value;
      }
      return num_bytes;
    }
  }

  public enum ConnectionEndEnum { tls_server=1,tls_client=2 };
  public class ConnectionEnd
  {
    public ConnectionEndEnum value;
    public int num_bytes = 1;

    public int Load(byte[] buffer,long offset) {
      long value;
      BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes,out value);
      if(Enum.IsDefined(typeof(ConnectionEndEnum), value)) {
        this.value = (ConnectionEndEnum)value;
      }
      return num_bytes;
    }
  }

  public enum PRFAlgorithmEnum { tls_tls_prf_sha256=1 };
  public class PRFAlgorithm
  {
    public PRFAlgorithmEnum value;
    public int num_bytes = 1;

    public int Load(byte[] buffer,long offset) {
      long value;
      BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes,out value);
      if(Enum.IsDefined(typeof(PRFAlgorithmEnum), value)) {
        this.value = (PRFAlgorithmEnum)value;
      }
      return num_bytes;
    }
  }

  public enum BulkCipherAlgorithmEnum { tls_null=1,tls_rc4=2,tls_three_des=3,tls_aes=4 };
  public class BulkCipherAlgorithm
  {
    public BulkCipherAlgorithmEnum value;
    public int num_bytes = 1;

    public int Load(byte[] buffer,long offset) {
      long value;
      BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes,out value);
      if(Enum.IsDefined(typeof(BulkCipherAlgorithmEnum), value)) {
        this.value = (BulkCipherAlgorithmEnum)value;
      }
      return num_bytes;
    }
  }

  public enum CipherTypeEnum { tls_stream=1,tls_block=2,tls_aead=3 };
  public class CipherType
  {
    public CipherTypeEnum value;
    public int num_bytes = 1;

    public int Load(byte[] buffer,long offset) {
      long value;
      BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes,out value);
      if(Enum.IsDefined(typeof(CipherTypeEnum), value)) {
        this.value = (CipherTypeEnum)value;
      }
      return num_bytes;
    }
  }

  public enum MACAlgorithmEnum { tls_null=1,tls_hmac_md5=2,tls_hmac_sha1=3,tls_hmac_sha256=4,tls_hmac_sha384=5,tls_hmac_sha512=6 };
  public class MACAlgorithm
  {
    public MACAlgorithmEnum value;
    public int num_bytes = 1;

    public int Load(byte[] buffer,long offset) {
      long value;
      BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes,out value);
      if(Enum.IsDefined(typeof(MACAlgorithmEnum), value)) {
        this.value = (MACAlgorithmEnum)value;
      }
      return num_bytes;
    }
  }

  public enum Enum_0Enum { tls_change_cipher_spec=1 };
  public class Enum_0
  {
    public Enum_0Enum value;
    public int num_bytes = 1;

    public int Load(byte[] buffer,long offset) {
      long value;
      BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes,out value);
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

    public int Load(byte[] buffer,long offset) {
      long value;
      BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes,out value);
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

    public int Load(byte[] buffer,long offset) {
      long value;
      BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes,out value);
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

    public int Load(byte[] buffer,long offset) {
      long value;
      BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes,out value);
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

    public int Load(byte[] buffer,long offset) {
      long value;
      BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes,out value);
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

    public int Load(byte[] buffer,long offset) {
      long value;
      BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes,out value);
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

    public int Load(byte[] buffer,long offset) {
      long value;
      BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes,out value);
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

    public int Load(byte[] buffer,long offset) {
      long value;
      BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes,out value);
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

    public int Load(byte[] buffer,long offset) {
      long value;
      BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes,out value);
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

    public int Load(byte[] buffer,long offset) {
      long value;
      BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes,out value);
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

    public int Load(byte[] buffer,long offset) {
      long value;
      BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes,out value);
      if(Enum.IsDefined(typeof(PublicValueEncodingEnum), value)) {
        this.value = (PublicValueEncodingEnum)value;
      }
      return num_bytes;
    }
  }

  public class ProtocolVersion
  {
    public uint8 major = new uint8();
    public uint8 minor = new uint8();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = major.Load(buffer,new_offset);
      new_offset = minor.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class TLSPlaintext
  {
    public ContentType type = new ContentType();
    public ProtocolVersion version = new ProtocolVersion();
    public uint16 length = new uint16();
    public opaque fragment = new opaque();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = type.Load(buffer,new_offset);
      new_offset = version.Load(buffer,new_offset);
      new_offset = length.Load(buffer,new_offset);
      new_offset = fragment.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class TLSCompressed
  {
    public ContentType type = new ContentType();
    public ProtocolVersion version = new ProtocolVersion();
    public uint16 length = new uint16();
    public opaque fragment = new opaque();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = type.Load(buffer,new_offset);
      new_offset = version.Load(buffer,new_offset);
      new_offset = length.Load(buffer,new_offset);
      new_offset = fragment.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class SecurityParameters
  {
    public ConnectionEnd entity = new ConnectionEnd();
    public PRFAlgorithm prf_algorithm = new PRFAlgorithm();
    public BulkCipherAlgorithm bulk_cipher_algorithm = new BulkCipherAlgorithm();
    public CipherType cipher_type = new CipherType();
    public uint8 enc_key_length = new uint8();
    public uint8 block_length = new uint8();
    public uint8 fixed_iv_length = new uint8();
    public uint8 record_iv_length = new uint8();
    public MACAlgorithm mac_algorithm = new MACAlgorithm();
    public uint8 mac_length = new uint8();
    public uint8 mac_key_length = new uint8();
    public CompressionMethod compression_algorithm = new CompressionMethod();
    public opaque master_secret = new opaque();
    public opaque client_random = new opaque();
    public opaque server_random = new opaque();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = entity.Load(buffer,new_offset);
      new_offset = prf_algorithm.Load(buffer,new_offset);
      new_offset = bulk_cipher_algorithm.Load(buffer,new_offset);
      new_offset = cipher_type.Load(buffer,new_offset);
      new_offset = enc_key_length.Load(buffer,new_offset);
      new_offset = block_length.Load(buffer,new_offset);
      new_offset = fixed_iv_length.Load(buffer,new_offset);
      new_offset = record_iv_length.Load(buffer,new_offset);
      new_offset = mac_algorithm.Load(buffer,new_offset);
      new_offset = mac_length.Load(buffer,new_offset);
      new_offset = mac_key_length.Load(buffer,new_offset);
      new_offset = compression_algorithm.Load(buffer,new_offset);
      new_offset = master_secret.Load(buffer,new_offset);
      new_offset = client_random.Load(buffer,new_offset);
      new_offset = server_random.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class TLSCiphertext
  {
    public ContentType type = new ContentType();
    public ProtocolVersion version = new ProtocolVersion();
    public uint16 length = new uint16();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = type.Load(buffer,new_offset);
      new_offset = version.Load(buffer,new_offset);
      new_offset = length.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class GenericStreamCipher
  {
    public opaque content = new opaque();
    public opaque MAC = new opaque();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = content.Load(buffer,new_offset);
      new_offset = MAC.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class Struct_0
  {
    public opaque content = new opaque();
    public opaque MAC = new opaque();
    public uint8 padding = new uint8();
    public uint8 padding_length = new uint8();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = content.Load(buffer,new_offset);
      new_offset = MAC.Load(buffer,new_offset);
      new_offset = padding.Load(buffer,new_offset);
      new_offset = padding_length.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class GenericBlockCipher
  {
    public opaque IV = new opaque();
    public Struct_0 Struct_0_instance = new Struct_0();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = IV.Load(buffer,new_offset);
      new_offset = Struct_0_instance.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class Struct_1
  {
    public opaque content = new opaque();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = content.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class GenericAEADCipher
  {
    public opaque nonce_explicit = new opaque();
    public Struct_1 Struct_1_instance = new Struct_1();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = nonce_explicit.Load(buffer,new_offset);
      new_offset = Struct_1_instance.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class ChangeCipherSpec
  {
    public Enum_0 type = new Enum_0();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = type.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class Alert
  {
    public AlertLevel level = new AlertLevel();
    public AlertDescription description = new AlertDescription();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = level.Load(buffer,new_offset);
      new_offset = description.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class Handshake
  {
    public HandshakeType msg_type = new HandshakeType();
    public uint24 length = new uint24();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = msg_type.Load(buffer,new_offset);
      new_offset = length.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class HelloRequest
  {
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      return new_offset;
    }
  }
  public class Random
  {
    public uint32 gmt_unix_time = new uint32();
    public opaque random_bytes = new opaque();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = gmt_unix_time.Load(buffer,new_offset);
      new_offset = random_bytes.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class SessionID
  {
    public opaque data = new opaque();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = data.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class CipherSuite
  {
    public uint8 data = new uint8();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = data.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class Struct_2
  {
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      return new_offset;
    }
  }
  public class ClientHello
  {
    public ProtocolVersion client_version = new ProtocolVersion();
    public Random random = new Random();
    public SessionID session_id = new SessionID();
    public CipherSuite cipher_suites = new CipherSuite();
    public CompressionMethod compression_methods = new CompressionMethod();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = client_version.Load(buffer,new_offset);
      new_offset = random.Load(buffer,new_offset);
      new_offset = session_id.Load(buffer,new_offset);
      new_offset = cipher_suites.Load(buffer,new_offset);
      new_offset = compression_methods.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class Struct_3
  {
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      return new_offset;
    }
  }
  public class ServerHello
  {
    public ProtocolVersion server_version = new ProtocolVersion();
    public Random random = new Random();
    public SessionID session_id = new SessionID();
    public CipherSuite cipher_suite = new CipherSuite();
    public CompressionMethod compression_method = new CompressionMethod();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = server_version.Load(buffer,new_offset);
      new_offset = random.Load(buffer,new_offset);
      new_offset = session_id.Load(buffer,new_offset);
      new_offset = cipher_suite.Load(buffer,new_offset);
      new_offset = compression_method.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class Extension
  {
    public ExtensionType extension_type = new ExtensionType();
    public opaque extension_data = new opaque();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = extension_type.Load(buffer,new_offset);
      new_offset = extension_data.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class SignatureAndHashAlgorithm
  {
    public HashAlgorithm hash = new HashAlgorithm();
    public SignatureAlgorithm signature = new SignatureAlgorithm();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = hash.Load(buffer,new_offset);
      new_offset = signature.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class supported_signature_algorithms
  {
    public SignatureAndHashAlgorithm data = new SignatureAndHashAlgorithm();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = data.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class ASN1Cert
  {
    public opaque data = new opaque();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = data.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class Certificate
  {
    public ASN1Cert certificate_list = new ASN1Cert();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = certificate_list.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class ServerDHParams
  {
    public opaque dh_p = new opaque();
    public opaque dh_g = new opaque();
    public opaque dh_Ys = new opaque();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = dh_p.Load(buffer,new_offset);
      new_offset = dh_g.Load(buffer,new_offset);
      new_offset = dh_Ys.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class Struct_4
  {
    public opaque client_random = new opaque();
    public opaque server_random = new opaque();
		public ServerDHParams paramsx = new ServerDHParams();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = client_random.Load(buffer,new_offset);
      new_offset = server_random.Load(buffer,new_offset);
			new_offset = paramsx.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class Struct_5
  {
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      return new_offset;
    }
  }
  public class ServerKeyExchange
  {
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      return new_offset;
    }
  }
  public class DistinguishedName
  {
    public opaque data = new opaque();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = data.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class CertificateRequest
  {
    public ClientCertificateType certificate_types = new ClientCertificateType();
    public DistinguishedName certificate_authorities = new DistinguishedName();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = certificate_types.Load(buffer,new_offset);
      new_offset = certificate_authorities.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class ServerHelloDone
  {
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      return new_offset;
    }
  }
  public class ClientKeyExchange
  {
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      return new_offset;
    }
  }
  public class PreMasterSecret
  {
    public ProtocolVersion client_version = new ProtocolVersion();
    public opaque random = new opaque();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = client_version.Load(buffer,new_offset);
      new_offset = random.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class EncryptedPreMasterSecret
  {
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      return new_offset;
    }
  }
  public class Struct_6
  {
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      return new_offset;
    }
  }
  public class ClientDiffieHellmanPublic
  {
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      return new_offset;
    }
  }
  public class Struct_7
  {
    public opaque handshake_messages = new opaque();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = handshake_messages.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class CertificateVerify
  {
    public Struct_7 Struct_7_instance = new Struct_7();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = Struct_7_instance.Load(buffer,new_offset);
      return new_offset;
    }
  }
  public class Finished
  {
    public opaque verify_data = new opaque();
    public long Load(byte[] buffer,long offset) {
      long new_offset = offset;
      new_offset = verify_data.Load(buffer,new_offset);
      return new_offset;
    }
  }
}
