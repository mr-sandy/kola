import React from 'react';

const style = {
    position: 'relative',
    height: '100%',
    width: '60px',
    backgroundColor: '#333',
    color: '#eee',
    float: 'left',
    zIndex: '200',
    paddingTop: '4px',
    overflow: 'hidden'};

const footerStyle = {
    position: 'absolute',
    bottom: '0',
    left: '0',
    right: '0',
    padding: '10px'
};

const buttonStyle =
{
    height: '36px',
    width: '36px',
    color: '#fff',
    backgroundColor: '#555',
    borderWidth: '2px',
    borderColor: '#555',
    borderStyle: 'solid'
}

const SideBar = props => {

    return (
    <div style={style}>
        <div style={footerStyle}>
            <button style={buttonStyle} type="button" title="Pin Toolbars">
                <i className="fa fa-thumb-tack fa-lg"></i>
            </button>
        </div>
    </div>
    );
}

export default SideBar;