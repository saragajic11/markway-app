import { FC, memo } from 'react';
import { useFormContext } from 'react-hook-form';

type Props = {
  options: {
    value?: string | readonly string[] | number;
    label: string;
  }[];
  name: string;
  selected?: boolean;
  optionLabel: string;
  defaultValue: {
    value: number | undefined;
  };
  register: any;
};

const CustomSignleSelect: FC<Props> = ({
  options,
  name,
  selected = true,
  optionLabel,
  defaultValue,
  register,
}) => {
  return (
    <div className='select-container'>
      <label htmlFor={name}>{optionLabel}</label>
      <select id={name} {...register(name, { required: true })}>
        <option selected={selected} disabled value=''>
          Izaberi
        </option>
        {options.map((option, idx) => (
          <option
            key={`custom-single-select-${name}-${idx}`}
            value={option.value}
            selected={option.value === defaultValue?.value}
          >
            {option.label}
          </option>
        ))}
      </select>
    </div>
  );
};

export default memo(CustomSignleSelect);
