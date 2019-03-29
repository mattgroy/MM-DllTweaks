using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISessionRubberOnTrackWidget : UIBaseSessionTopBarWidget
{
	// ADDED METHOD:
	private void UpdateLabelText()
	{
		this.rubberLevelLabel.text = this.mWeatherDetails.GetNormalizedTrackRubber().ToString("P0");
	}

	protected void Awake()
	{
		GameUtility.Assert(this.rubberAmount != null, "UISessionRubberOnTrackWidget.rubberAmount != null", this);
		GameUtility.Assert(this.rubberLevelLabel != null, "UISessionRubberOnTrackWidget.rubberLevelLabel != null", this);
		this.keybinding = KeyBinding.Name.RubberConditions;
		this.useKeyBinding = true;
		this.dropdownScript = this.dropdown.GetComponent<SessionInformationDropdown>();
	}

	private void Start()
	{
		this.mRubberLevel = this.mWeatherDetails.rubberLevel;
		this.rubberLevelLabel.text = Localisation.LocaliseEnum(this.mRubberLevel);
	}

	/* CHANGED METHOD:
	public override void OnEnter()
	{
		this.mWeatherDetails = Game.instance.sessionManager.currentSessionWeather;
	}
	*/

	public override void OnEnter()
	{
		this.mWeatherDetails = Game.instance.sessionManager.currentSessionWeather;
		this.UpdateLabelText();
	}

	/* CHANGED METHOD:
	private void Update()
	{
		GameUtility.SetSliderAmountIfDifferent(this.rubberAmount, this.mWeatherDetails.GetNormalizedTrackRubber(), 1000f);
		Weather.RubberLevel rubberLevel = this.mWeatherDetails.rubberLevel;
		if (rubberLevel != this.mRubberLevel)
		{
			this.mRubberLevel = rubberLevel;
			this.rubberLevelLabel.text = Localisation.LocaliseEnum(this.mRubberLevel);
		}
		this.CheckKeyBinding();
	}
	*/

	private void Update()
	{
		GameUtility.SetSliderAmountIfDifferent(this.rubberAmount, this.mWeatherDetails.GetNormalizedTrackRubber(), 1000f);
		this.UpdateLabelText();
		this.CheckKeyBinding();
	}

	public override void ToggleDropdown(bool inValue)
	{
		if (this.dropdownScript.dataType != SessionInformationDropdown.DataType.Rubber)
		{
			inValue = true;
			GameUtility.SetActive(this.dropdown, false);
		}
		if (inValue)
		{
			this.OpenDropdown();
		}
		else
		{
			this.CloseDropdown();
		}
	}

	public override void OpenDropdown()
	{
		this.dropdown.GetComponent<SessionInformationDropdown>().dataType = SessionInformationDropdown.DataType.Rubber;
		GameUtility.SetActive(this.dropdown, true);
	}

	[SerializeField]
	private Slider rubberAmount;

	[SerializeField]
	private TextMeshProUGUI rubberLevelLabel;

	private SessionWeatherDetails mWeatherDetails;

	private Weather.RubberLevel mRubberLevel;

	private SessionInformationDropdown dropdownScript;
}
