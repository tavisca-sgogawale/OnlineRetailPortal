﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineRetailPortal.Contracts {
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
    public class ErrorMessage {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorMessage() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("OnlineRetailPortal.Contracts.ErrorMessage", typeof(ErrorMessage).Assembly);
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
        ///   Looks up a localized string similar to .
        /// </summary>
        public static string Empty {
            get {
                return ResourceManager.GetString("Empty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} should be at least  {1} characters..
        /// </summary>
        public static string GreaterCharacter {
            get {
                return ResourceManager.GetString("GreaterCharacter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} should be less than Todays Date..
        /// </summary>
        public static string GreaterDate {
            get {
                return ResourceManager.GetString("GreaterDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} should be greater than  {1}..
        /// </summary>
        public static string GreaterValue {
            get {
                return ResourceManager.GetString("GreaterValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Errors occured.
        /// </summary>
        public static string InvalidRequest {
            get {
                return ResourceManager.GetString("InvalidRequest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} can not be blank..
        /// </summary>
        public static string MissingField {
            get {
                return ResourceManager.GetString("MissingField", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} can not be null..
        /// </summary>
        public static string NullField {
            get {
                return ResourceManager.GetString("NullField", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Request is null.
        /// </summary>
        public static string NullRequest {
            get {
                return ResourceManager.GetString("NullRequest", resourceCulture);
            }
        }
    }
}
