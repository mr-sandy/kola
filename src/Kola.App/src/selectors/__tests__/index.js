import { selectedComponentProperties } from '../index';

describe('when selecting the selected component\'s properties', () => {
    const state = {
        template: {
            components: [
                {
                    name: 'component0'
                },
                {
                    name: 'component1',
                    properties: [
                        {
                            name: 'propertyx'
                        },
                        {
                            name: 'propertyx'
                        }
                    ]
                },
                {
                    name: 'component2',
                    components: [
                        {
                            name: 'component2-0',
                            properties: [
                                {
                                    name: 'property1'
                                },
                                {
                                    name: 'property2'
                                }
                            ]
                        },
                        {
                            name: 'component2-1',
                            components: [
                            ]
                        }
                    ]
                }
            ]
        },
        selection: {
            selectedComponent: '/2/0',
            selectedProperty: 'property2'
        }
    };

    it('should work add a selected flag to the selected property', () => {

        const result = selectedComponentProperties(state);

        const expectedResult = [
            {
                name: 'property1',
                selected: false
        },
            {
                name: 'property2',
                selected: true
            }
        ];

        expect(result).toEqual(expectedResult);
    });
});