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
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation.Configuration;
using Microsoft.Practices.ServiceFactory.ServiceContracts;
using Microsoft.VisualStudio.Modeling;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System.Globalization;

namespace Microsoft.Practices.ServiceFactory.Validation
{
	/// <summary>
	/// Validate that all elements in a collection of type MessagePart have unique values for a specified property.
	/// </summary>
	[ConfigurationElementType(typeof(CustomValidatorData))]
	public class MessagePartElementCollectionValidator : UniqueNamedElementCollectionValidator<MessagePart>
	{
		public MessagePartElementCollectionValidator(NameValueCollection attributes)
			: base(attributes)
		{
		}

		protected override void DoValidateCollectionItem(MessagePart objectToValidate, object currentTarget, string key, ValidationResults validationResults)
		{
			Message contract = currentTarget as Message;

			if (contract != null)
			{
				if (String.Compare(contract.Name, objectToValidate.Name, StringComparison.Ordinal) == 0)
				{
					validationResults.AddResult(
						new ValidationResult(String.Format(CultureInfo.CurrentUICulture, this.MessageTemplate, this.GetObjectName(currentTarget)), objectToValidate, key, String.Empty, this));
				}
			}
			base.DoValidateCollectionItem(objectToValidate, currentTarget, key, validationResults);
		}

		protected override string DefaultMessageTemplate
		{
			get
			{
				return Resources.MessagePartElementCollectionValidatorMessage;
			}
		}
	}
}
