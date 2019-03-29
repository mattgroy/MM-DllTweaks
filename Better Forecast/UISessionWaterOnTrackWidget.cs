using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISessionWaterOnTrackWidget : UIBaseSessionTopBarWidget
{
	// ADDED METHOD:
	private void UpdateLabelText()
	{
		this.waterLevelLabel.text = this.mWeatherDetails.GetNormalizedTrackWater().ToString("P0");
	}

	protected void Awake()
	{
		GameUtility.Assert(this.waterAmount != null, "UISessionWaterOnTrackWidget.waterAmount != null", this);
		GameUtility.Assert(this.waterLevelLabel != null, "UISessionWaterOnTrackWidget.waterLevelLabel != null", this);
		this.keybinding = KeyBinding.Name.WaterConditions;
		this.useKeyBinding = true;
		this.dropdownScript = this.dropdown.GetComponent<SessionInformationDropdown>();
	}

	/* CHANGED METHOD:
	public override void OnEnter()
	{
		this.mWeatherDetails = Game.instance.sessionManager.currentSessionWeather;
		this.waterLevelLabel.text = Localisation.LocaliseEnum(this.mCachedWaterLevel);
	}
	*/

	public override void OnEnter()
	{
		this.mWeatherDetails = Game.instance.sessionManager.currentSessionWeather;
		this.UpdateLabelText();
	}

	public override void ToggleDropdown(bool inValue)
	{
		if (this.dropdownScript.dataType != SessionInformationDropdown.DataType.Water)
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

	/* CHANGED METHOD:
	private void Update()
	{
		GameUtility.SetSliderAmountIfDifferent(this.waterAmount, this.mWeatherDetails.GetNormalizedTrackWater(), 1000f);
		if (this.mCachedWaterLevel != this.mWeatherDetails.waterLevel)
		{
			this.mCachedWaterLevel = this.mWeatherDetails.waterLevel;
			this.waterLevelLabel.text = Localisation.LocaliseEnum(this.mCachedWaterLevel);
		}
		this.CheckKeyBinding();
	}
	*/

	private void Update()
	{
		GameUtility.SetSliderAmountIfDifferent(this.waterAmount, this.mWeatherDetails.GetNormalizedTrackWater(), 1000f);
		this.UpdateLabelText();
		this.CheckKeyBinding();
	}

	public override void OpenDropdown()
	{
		this.dropdown.GetComponent<SessionInformationDropdown>().dataType = SessionInformationDropdown.DataType.Water;
		GameUtility.SetActive(this.dropdown, true);
	}

	[SerializeField]
	private Slider waterAmount;

	[SerializeField]
	private TextMeshProUGUI waterLevelLabel;

	private SessionWeatherDetails mWeatherDetails;

	private Weather.WaterLevel mCachedWaterLevel;

	private SessionInformationDropdown dropdownScript;
}
