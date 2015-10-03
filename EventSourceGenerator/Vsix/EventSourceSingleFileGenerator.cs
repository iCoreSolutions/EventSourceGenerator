using System;
using System.Runtime.InteropServices;
using Microsoft.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Simplification;
using Alphaleonis.Vsx;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Alphaleonis.EventSourceGenerator
{
   [ComVisible(true)]
   [Guid("C0B0D7EA-A1E9-46B7-B7B2-93EC5249A719")]
   [Microsoft.VisualStudio.Shell.CodeGeneratorRegistration(typeof(EventSourceSingleFileGenerator), "C# Event Source Class Generator", VSLangProj80.vsContextGuids.vsContextGuidVCSProject, GeneratesDesignTimeSource = true, GeneratorRegKeyName = Name)]
   [Microsoft.VisualStudio.Shell.ProvideObject(typeof(EventSourceSingleFileGenerator))]
   public class EventSourceSingleFileGenerator : CSharpRoslynCodeGenerator
   {
#pragma warning disable 0414
      //The name of this generator (use for 'Custom Tool' property of project item)
      internal const string Name = "EventSourceGenerator";
#pragma warning restore 0414

      public EventSourceSingleFileGenerator()
      {
      }

      protected override Task<CompilationUnitSyntax> GenerateCompilationUnit(Document sourceDocument)
      {
         return EventSourceGenerator.GenerateEventSourceImplementations(sourceDocument);
      }

      protected override string GetDefaultExtension()
      {
         return ".g.cs";
      }

      
   }
}