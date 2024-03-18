import React from "react";
import { MenuItem } from "@mui/material";

export const getDropdownOptions = (array, label, valueKey = 'id', { label: selectLabel = 'Izaberi', classes = '' } = { label: 'Izaberi', classes: '' }, {img = false} = {img: false}, disableMenuItem = false, addCarrier?) => {
    if (!array) {
        return;
    }
    const groups = array.reduce((groups, item) => {
        let key = item?.parent?.id ? item?.parent?.id : 'root';
        return {
            ...groups,
            [key]: [...(groups[key] || []), item]
        }
    }, { 'root': [] });

    let result = [
        <MenuItem disabled={disableMenuItem} key={'menu-option-select-'+label + 1} className={classes} value={-1}>{selectLabel}</MenuItem>
    ];

    if (!groups['root']) {
        return result;
    }

    for (let rootItem of groups['root']) {
        result.push(<MenuItem key={'menu-option-' + label + '-' + result.length + 1} value={rootItem[valueKey]} divider={!!groups[rootItem.id]}> {img && <img src={rootItem[img]} className="dropdown-option-img"></img>} {rootItem[label]}</MenuItem>)
        if (groups[rootItem.id]) {
            for (let item of groups[rootItem.id]) {
                result.push(<MenuItem key={'menu-option-' + label + '-' + result.length + 1} value={item[valueKey]} className={'sub-item'}>{item[label]}</MenuItem>)
            }
        }
    }

    if(addCarrier) result.push(<MenuItem onClick={addCarrier}>Dodaj novog prevoznika</MenuItem>)

    return result;
}
