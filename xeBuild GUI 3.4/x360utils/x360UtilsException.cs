﻿namespace xeBuild_GUI.x360utils
{
    using System;

    public sealed class X360UtilsException: Exception {
        #region X360UtilsErrors enum

        public enum X360UtilsErrors {
            TooShortKey,
            TooLongKey,
            InvalidKeyHamming,
            InvalidKeyECD,
            NoValidKeyFound,
            DataTooSmall,
            DataTooBig,
            DataNotFound,
            DataNotDecrypted,
            BadChecksum,
            DataInvalid,
            DataDecryptionFailed,
            UnkownMetaType,
            BadBlockDetected,
            UnkownPatchset,
            BadMagic
        }

        #endregion

        public readonly X360UtilsErrors ErrorCode;

        public new readonly string Message;

        internal X360UtilsException(X360UtilsErrors errorCode, string message = "") {
            ErrorCode = errorCode;
            Message = message;
        }

        public override string ToString() { return string.Format("x360UtilsException!{0}ErrorCode: {1}{0}Message: {2}{0}StackTrace: {0}{3}", Environment.NewLine, ErrorCode, Message, StackTrace); }
    }
}