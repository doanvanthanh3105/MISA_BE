//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MISA.ApplicationCore.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MISA.ApplicationCore.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Thêm không  thành công.
        /// </summary>
        public static string AddNotSuccess {
            get {
                return ResourceManager.GetString("AddNotSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Thêm thành công.
        /// </summary>
        public static string AddSuccess {
            get {
                return ResourceManager.GetString("AddSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Xóa không thành công.
        /// </summary>
        public static string DeleteNotSuccess {
            get {
                return ResourceManager.GetString("DeleteNotSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Xóa thành công.
        /// </summary>
        public static string DeleteSuccess {
            get {
                return ResourceManager.GetString("DeleteSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to  {0} đã bị trùng.
        /// </summary>
        public static string DuplicateValidation {
            get {
                return ResourceManager.GetString("DuplicateValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} có giới hạn độ dài là {1} ký tự.
        /// </summary>
        public static string MaxLengthValidation {
            get {
                return ResourceManager.GetString("MaxLengthValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} không được để trống.
        /// </summary>
        public static string NullOrEmptyValidation {
            get {
                return ResourceManager.GetString("NullOrEmptyValidation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Máy chủ bị lỗi, vui lòng thử lại xem.
        /// </summary>
        public static string ServerError {
            get {
                return ResourceManager.GetString("ServerError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sửa không thành công.
        /// </summary>
        public static string UpdateNotSuccess {
            get {
                return ResourceManager.GetString("UpdateNotSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sửa thành công.
        /// </summary>
        public static string UpdateSuccess {
            get {
                return ResourceManager.GetString("UpdateSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dữ liệu không hợp lệ.
        /// </summary>
        public static string ValidationError {
            get {
                return ResourceManager.GetString("ValidationError", resourceCulture);
            }
        }
    }
}
