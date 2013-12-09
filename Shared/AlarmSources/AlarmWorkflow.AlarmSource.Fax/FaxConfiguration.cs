﻿// This file is part of AlarmWorkflow.
// 
// AlarmWorkflow is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// AlarmWorkflow is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with AlarmWorkflow.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.ObjectModel;
using AlarmWorkflow.BackendService.SettingsContracts;
using AlarmWorkflow.Shared;
using AlarmWorkflow.Shared.Core;
using AlarmWorkflow.Shared.Specialized;

namespace AlarmWorkflow.AlarmSource.Fax
{
    internal sealed class FaxConfiguration : DisposableObject
    {
        #region Fields

        private ISettingsServiceInternal _settings;

        #endregion

        #region Properties

        internal string FaxPath { get; private set; }
        internal string ArchivePath { get; private set; }
        internal string AnalysisPath { get; private set; }
        internal string OCRSoftware { get; private set; }
        internal string OCRSoftwarePath { get; private set; }
        internal string AlarmFaxParserAlias { get; private set; }
        internal int RoutineInterval { get; private set; }
        internal ReadOnlyCollection<string> TestFaxKeywords { get; private set; }
        internal ReplaceDictionary ReplaceDictionary
        {
            get { return _settings.GetSetting(SettingKeys.ReplaceDictionary).GetValue<ReplaceDictionary>(); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FaxConfiguration"/> class.
        /// </summary>
        /// <param name="serviceProvider"></param>
        public FaxConfiguration(IServiceProvider serviceProvider)
        {
            _settings = serviceProvider.GetService<ISettingsServiceInternal>();

            this.FaxPath = _settings.GetSetting("FaxAlarmSource", "FaxPath").GetValue<string>();
            this.ArchivePath = _settings.GetSetting("FaxAlarmSource", "ArchivePath").GetValue<string>();
            this.AnalysisPath = _settings.GetSetting("FaxAlarmSource", "AnalysisPath").GetValue<string>();
            this.AlarmFaxParserAlias = _settings.GetSetting("FaxAlarmSource", "AlarmfaxParser").GetValue<string>();

            this.OCRSoftware = _settings.GetSetting("FaxAlarmSource", "OCR.Software").GetValue<string>();
            this.OCRSoftwarePath = _settings.GetSetting("FaxAlarmSource", "OCR.Path").GetValue<string>();

            this.RoutineInterval = _settings.GetSetting("FaxAlarmSource", "Routine.Interval").GetValue<int>();
            this.TestFaxKeywords = new ReadOnlyCollection<string>(_settings.GetSetting("FaxAlarmSource", "TestFaxKeywords").GetValue<string>().Split(new[] { '\n', ';' }, StringSplitOptions.RemoveEmptyEntries));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        protected override void DisposeCore()
        {
            _settings = null;
        }

        #endregion

    }
}