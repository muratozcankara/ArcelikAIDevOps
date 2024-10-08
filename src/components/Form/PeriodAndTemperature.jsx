import "./PeriodAndTemperature.css";

function PeriodAndTemperature({ state, handleInputChange }) {
  //Step 2 - Model Temperature & Retention period settings
  return (
    <div className="pt-container">
      <div className="period-container">
        <label htmlFor="periodInput" className="form-item-title">
          Conversation retention period (days)
        </label>
        <input
          type="number"
          id="periodInput"
          className="text-input"
          value={state.crPeriod}
          onChange={(e) => handleInputChange("crPeriod", e.target.value)}
          min="0"
          max="100"
        />
      </div>

      <div className="range-container">
        <label htmlFor="rangeInput" className="form-item-title">
          Modal temperature: {Number(state.modelTemperature).toFixed(2)}
        </label>
        <input
          type="range"
          id="rangeInput"
          value={state.modelTemperature}
          onChange={(e) =>
            handleInputChange("modelTemperature", e.target.value)
          }
          min="-1.00"
          max="1.00"
          step="0.05"
        />
      </div>
    </div>
  );
}

export default PeriodAndTemperature;
