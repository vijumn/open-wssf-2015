//===============================================================================
// Microsoft patterns & practices
// Web Service Software Factory 2010
//===============================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===============================================================================
using Microsoft.VisualStudio.Modeling.Validation;
using Microsoft.Practices.Modeling.Validation;

namespace Microsoft.Practices.ServiceFactory.HostDesigner
{
	[ValidationState(ValidationState.Enabled)]
	public partial class Endpoint
	{
		public override Microsoft.Practices.Modeling.ExtensionProvider.Extension.IExtensionProvider ExtensionProvider
		{
			get
			{
				return this.ServiceDescription.HostApplication.ImplementationTechnology;
			}
		}

        #region Validation support

        [ValidationMethod(ValidationCategories.Menu)]
        private void OnValidate(ValidationContext context)
        {
            ValidationEngine.Validate(ValidationElementState.FirstElement, context, this);
        }

        public void ContinueValidation(ValidationContext context)
        {
            ValidationEngine.Validate(ValidationElementState.LinkedElement, context, this);
        }

        #endregion
	}
}
